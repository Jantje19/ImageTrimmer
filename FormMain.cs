using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTrimmer
{
				public partial class formMain : Form
				{
								string fileExtStr;
								private Thread t;

								public formMain()
								{
												InitializeComponent();

												// Displays an OpenFileDialog so the user can select a Cursor.  
												ofdImageSelector.Filter = "Image Files|*.png; *.jpg; *.jpeg|All files (*.*)|*.*";
												ofdImageSelector.Title = "Select an image file";
												ofdImageSelector.RestoreDirectory = true;

												if (ofdImageSelector.ShowDialog() == DialogResult.OK)
												{
																fileExtStr = GetFileExtFromStr(ofdImageSelector.FileName).ToLower();
																if (fileExtStr == "jpeg" || fileExtStr == "jpg")
																				MessageBox.Show("Due to the compression property of JPEG/JPG files, this program won't work as well as for PNG files", "Warning");

																try
																{
																				pbMain.Image = new Bitmap(ofdImageSelector.FileName);

																				this.BringToFront();
																				this.Activate();
																				this.Focus();
																}
																catch (Exception e)
																{
																				Console.WriteLine(e.StackTrace);
																				MessageBox.Show("Unable to load image: " + e.Message, "Error");
																}
												}
												else
												{
																exitApp();
												}
								}

								private void exitApp()
								{
												Application.Exit();
												Environment.Exit(1);
								}

								private void btnStart_Click(object sender, EventArgs e)
								{
												int searchColor = 255;
												if (rbBgWhite.Checked)
																searchColor = 255;
												else if (rbBgBlack.Checked)
																searchColor = 0;
												else
																MessageBox.Show("Invalid color selected", "Error");

												if (progressBar.Value >= 100)
												{
																// Save!
																SaveFileDialog dialog = new SaveFileDialog();

																dialog.Filter = "Image Files|*.png; *.jpg; *.jpeg|All files (*.*)|*.*";
																dialog.Title = "Select location to save file";
																dialog.DefaultExt = "." + fileExtStr;
																dialog.RestoreDirectory = true;
																dialog.OverwritePrompt = true;
																dialog.ValidateNames = true;
																dialog.AddExtension = true;

																if (dialog.ShowDialog() == DialogResult.OK)
																				pbMain.Image.Save(dialog.FileName, GetFileExtFromStr(fileExtStr, null));
												}
												else if (pbMain.Image != null)
												{
																btnStart.Enabled = false;
																btnCancel.Enabled = true;

																ImageTrimmerThreaded imageTrimmerThreaded = new ImageTrimmerThreaded((Bitmap)pbMain.Image, searchColor);
																imageTrimmerThreaded.OnProgress += new EventHandler<TrimmerEventArgs>(imagetrimmerThreaded_Progress);
																imageTrimmerThreaded.OnImage += new EventHandler<TrimmerEventArgs>(imagetrimmerThreaded_Image);

																t = new Thread(new ThreadStart(imageTrimmerThreaded.Start));
																t.Start();
												}
								}

								private ImageFormat GetFileExtFromStr(string ext, string notNeededButErg)
								{
												switch (ext.ToLower())
												{
																case "png":
																				return System.Drawing.Imaging.ImageFormat.Png;
																case "jpg":
																				return System.Drawing.Imaging.ImageFormat.Jpeg;
																case "jpeg":
																				return System.Drawing.Imaging.ImageFormat.Jpeg;
																default:
																				return System.Drawing.Imaging.ImageFormat.Png;
												}
								}

								private string GetFileExtFromStr(string fileName)
								{
												return fileName.Split('.').Last();
								}

								private void imagetrimmerThreaded_Image(object sender, TrimmerEventArgs e)
								{
												try
												{
																pbMain.Image = e.Image;
												}
												catch (Exception) { }
								}

								private void imagetrimmerThreaded_Progress(object sender, TrimmerEventArgs e)
								{
												lblProgress.Invoke((MethodInvoker)delegate {
																lblProgress.Text = e.ProgressPercentage + "%";
												});

												progressBar.Invoke((MethodInvoker)delegate {
																progressBar.Value = e.ProgressPercentage;
												});

												if (e.ProgressPercentage >= 100)
												{
																btnStart.Invoke((MethodInvoker)delegate {
																				btnStart.Text = "Save file";
																});

																btnStart.Invoke((MethodInvoker)delegate {
																				btnStart.Enabled = true;
																});

																btnCancel.Invoke((MethodInvoker)delegate {
																				btnCancel.Enabled = false;
																});
												}
								}

								private void btnCancel_Click(object sender, EventArgs e)
								{
												btnCancel.Enabled = false;
												btnStart.Enabled = true;

												t.Abort();
								}
				}
}
