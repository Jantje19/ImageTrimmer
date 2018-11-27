using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTrimmer
{
				public enum Events
				{
								Progress,
								NewImage
				}

				public class TrimmerEventArgs : EventArgs
				{
								public TrimmerEventArgs(Events evts)
								{
												events = evts;
								}

								public Events events { get; private set; }
								public int ProgressPercentage { get; set; }
								public Bitmap Image { get; set; }
				}

				class ImageTrimmerThreaded
				{
								public event EventHandler<TrimmerEventArgs> OnProgress;
								public event EventHandler<TrimmerEventArgs> OnImage;

								private Bitmap cursorBitmap;
								private int searchColor;
								private Bitmap bitmap;

								public ImageTrimmerThreaded(Bitmap b, int sc)
								{
												cursorBitmap = new Bitmap(b);
												searchColor = sc;
												bitmap = b;

												if (searchColor != 255 && searchColor != 0)
																searchColor = 255;
								}

								public void Start()
								{
												TrimmerEventArgs e = new TrimmerEventArgs(Events.NewImage);
												Bitmap newBitmap = new Bitmap(bitmap, bitmap.Size);

												bool[] emptyPixelsHorizontal = new bool[bitmap.Height];
												bool[] emptyPixelsVertical = new bool[bitmap.Width];

												for (int y = 0; y < bitmap.Height; y++)
												{
																for (int x = 0; x < bitmap.Width; x++)
																{
																				try
																				{
																								cursorBitmap.SetPixel(x, y, Color.FromArgb(cursorBitmap.GetPixel(x, y).ToArgb() ^ 0xffffff));
																				}
																				catch (Exception) { }

																				e.Image = cursorBitmap;
																				OnImage?.Invoke(this, e);

																				Color c = bitmap.GetPixel(x, y);

																				if (c.R == searchColor && c.G == searchColor && c.B == searchColor)
																				{
																								newBitmap.SetPixel(x, y, Color.Purple);
																								emptyPixelsHorizontal[y] = true;
																				}
																				else
																				{
																								emptyPixelsHorizontal[y] = false;
																								break;
																				}

																				UpdateProgress((int)((double)(y * bitmap.Width + x) / (double)(bitmap.Width * bitmap.Height) * 100) / 2);
																}
												}

												for (int x = 0; x < bitmap.Width; x++)
												{
																for (int y = 0; y < bitmap.Height; y++)
																{
																				Color c = bitmap.GetPixel(x, y);

																				try
																				{
																								Color currentColor = cursorBitmap.GetPixel(x, y);

																								if (currentColor.Equals(c))
																												cursorBitmap.SetPixel(x, y, Color.FromArgb(currentColor.ToArgb() ^ 0xffffff));
																				}
																				catch (Exception) { }

																				e.Image = cursorBitmap;
																				OnImage?.Invoke(this, e);

																				if (c.R == searchColor && c.G == searchColor && c.B == searchColor)
																				{
																								newBitmap.SetPixel(x, y, Color.Purple);
																								emptyPixelsVertical[x] = true;
																				}
																				else
																				{
																								emptyPixelsVertical[x] = false;
																								break;
																				}

																				UpdateProgress((int)((double)(x * bitmap.Height + y) / (double)(bitmap.Width * bitmap.Height) * 100) / 2 + 50);
																}
												}

												e.Image = newBitmap;
												OnImage?.Invoke(this, e);
												cursorBitmap.Dispose();

												int[] emptyPixelLocations = FindEmptyPixels(emptyPixelsHorizontal, emptyPixelsVertical);
												Console.WriteLine(String.Join(", ", emptyPixelLocations));
												if (emptyPixelLocations != null)
												{
																// drawBox(newBitmap, emptyPixelLocations[0] - 1, emptyPixelLocations[1] - 1, emptyPixelLocations[0] + 1, emptyPixelLocations[1] + 1, Color.Green);
																// drawBox(newBitmap, emptyPixelLocations[2] - 1, emptyPixelLocations[3] - 1, emptyPixelLocations[2] + 1, emptyPixelLocations[3] + 1, Color.Orange);

																int newHeight = emptyPixelLocations[3] - emptyPixelLocations[1];
																int newWidth = emptyPixelLocations[2] - emptyPixelLocations[0];
																newBitmap.Dispose();

																Rectangle cutout = new Rectangle(emptyPixelLocations[0], emptyPixelLocations[1], emptyPixelLocations[2] - emptyPixelLocations[0], emptyPixelLocations[3] - emptyPixelLocations[1]);
																Console.WriteLine(cutout.ToString());
																newBitmap = bitmap.Clone(cutout, bitmap.PixelFormat);
																bitmap.Dispose();

																try
																{
																				e.Image = newBitmap;
																				OnImage?.Invoke(this, e);
																} catch (Exception) { }
												}

												UpdateProgress(100);
								}

								private int[] FindEmptyPixels(bool[] h, bool[] v)
								{
												int startX = -1;
												int startY = -1;
												int endX = -1;
												int endY = -1;

												// Start
												for (int i = 0; i < h.Length; i++)
												{
																if (h[i])
																				continue;

																for (int j = 0; j < v.Length; j++)
																{
																				if (!h[i] && !v[j])
																				{
																								startX = i;
																								startY = j;

																								break;
																				}
																}

																if (startX > -1 && startY > -1)
																				break;
												}

												// End
												for (int i = h.Length - 1; i >= 0; i--)
												{
																if (h[i])
																				continue;

																for (int j = v.Length - 1; j >= 0; j--)
																{
																				if (!h[i] && !v[j])
																				{
																								endX = j;
																								endY = i;

																								break;
																				}
																}

																if (endX > -1 && endY > -1)
																				break;
												}

												if (startX > -1 && startY > -1 && endX > -1 && endY > -1)
																return new int[] { startX, startY, endX, endY };
												else
																return null;
								}

								private void drawBox(Bitmap bitmap, int startX, int startY, int endX, int endY, Color c)
								{
												for (int x = 0; x <= endX - startX; x++)
												{
																for (int y = 0; y <= endY - startY; y++)
																{
																				try
																				{
																								bitmap.SetPixel(startX + x, startY + y, c);
																				}
																				catch (Exception) { }
																}
												}
								}

								private void UpdateProgress(int progress)
								{
												TrimmerEventArgs e = new TrimmerEventArgs(Events.Progress);
												e.ProgressPercentage = progress;
												OnProgress?.Invoke(this, e);
								}
				}
}
