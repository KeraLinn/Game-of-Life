using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KL___Game_of_Life_Program
{
	public partial class Form1 : Form //partial keyword is saying it's only a portion of the code for form 1, the rest of code is in form1.Designer.cs
	{
		// The universe array
		bool[,] universe = new bool[15, 15];
		bool[,] scratchPad = new bool[15, 15];

		// Drawing colors
		Color gridColor = Color.Black;
		Color cellColor = Color.Gray;

		// The Timer class
		Timer timer = new Timer();

		// Generation count
		int generations = 0;

		//bool for NeighborCount visible in Cells
		bool isNeighborVisible = true;
		//bool for BorderControls
		bool isFinite = true;
		//bools for HUD
		bool isHUDVisible = true;
		//bool for Grid Visible
		bool isGridVisible = true;

		public Form1()
		{
			InitializeComponent();

			graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
			//graphicsPanel1.Height = Properties.Settings.Default.UniverseSizeHeight;
			//graphicsPanel1.Width = Properties.Settings.Default.UniverseSizeWidth;
			cellColor = Properties.Settings.Default.cellColor;
			gridColor = Properties.Settings.Default.gridColor;


			// Setup the timer
			timer.Interval = 100; // milliseconds
			timer.Tick += Timer_Tick;
			timer.Enabled = false; // start timer running //true = run, false = stop
		}

		// Calculate the next generation of cells
		private void NextGeneration()
		{
			// Iterate through the universe in the y, top to bottom
			for (int y = 0; y < universe.GetLength(1); y++)
			{
				// Iterate through the universe in the x, left to right
				for (int x = 0; x < universe.GetLength(0); x++)
				{
					scratchPad[x, y] = false;
					//get neighborcount
					int count;
					if (isFinite)
					{
						count = CountNeighborsFinite(x, y);
					}
					else
					{
						count = CountNeighborsToroidal(x, y);
					}

					if (universe[x, y] == true) //if cell is currently alive
					{
						if (count < 2)
						{ scratchPad[x, y] = false; }

						else if (count > 3)
						{ scratchPad[x, y] = false; }

						else if (count == 2 || count == 3)
						{ scratchPad[x, y] = true; }
					}
					else //if cell currently dead
					{
						if (count == 3)
						{ scratchPad[x, y] = true; }
					}
				}
			}
			bool[,] temp = universe;
			universe = scratchPad;
			scratchPad = temp;
			//invalidate graphics panel
			graphicsPanel1.Invalidate();

			// Increment generation count
			generations++;

			// Update status strip generations
			toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
			HowManyAlive();
		}
		private void HowManyAlive()
		{
			int alive = 0;
			for (int y = 0; y < universe.GetLength(1); y++)
			{
				for (int x = 0; x < universe.GetLength(0); x++)
				{
					if (universe[x, y] == true)
					{
						alive++;
					}
				}

			}
			StripStatusLabelAlive.Text = "Alive = " + alive.ToString();
		}
		private int CountNeighborsFinite(int x, int y)
		{
			int neighborNum = 0;
			int xLen = universe.GetLength(0);
			int yLen = universe.GetLength(1);
			for (int yOffset = -1; yOffset <= 1; yOffset++)
			{
				for (int xOffset = -1; xOffset <= 1; xOffset++)
				{
					int xCheck = x + xOffset;
					int yCheck = y + yOffset;
					if (xOffset == 0 && yOffset == 0) { continue; }     // if xOffset and yOffset are both equal to 0 then continue
					if (xCheck < 0) { continue; }       // if xCheck is less than 0 then continue
					if (yCheck < 0) { continue; }       // if yCheck is less than 0 then continue
					if (xCheck >= xLen) { continue; }   // if xCheck is greater than or equal too xLen then continue
					if (yCheck >= yLen) { continue; }       // if yCheck is greater than or equal too yLen then continue

					if (universe[xCheck, yCheck] == true) neighborNum++;
				}
			}
			HowManyAlive();
			return neighborNum;
		}
		private int CountNeighborsToroidal(int x, int y)
		{
			int neighborNum = 0;
			int xLen = universe.GetLength(0);
			int yLen = universe.GetLength(1);
			for (int yOffset = -1; yOffset <= 1; yOffset++)
			{
				for (int xOffset = -1; xOffset <= 1; xOffset++)
				{
					int xCheck = x + xOffset;
					int yCheck = y + yOffset;
					if (xOffset == 0 && yOffset == 0) { continue; } // if xOffset and yOffset are both equal to 0 then continue
					if (xCheck < 0) { xCheck = xLen - 1; }  // if xCheck is less than 0 then set to xLen - 1
					if (yCheck < 0) { yCheck = yLen - 1; }  // if yCheck is less than 0 then set to yLen - 1
					if (xCheck >= xLen) { xCheck = 0; } // if xCheck is greater than or equal too xLen then set to 0
					if (yCheck >= yLen) { yCheck = 0; } // if yCheck is greater than or equal too yLen then set to 0

					if (universe[xCheck, yCheck] == true) neighborNum++;
				}
			}
			HowManyAlive();
			return neighborNum;
		}
		// The event called by the timer every Interval milliseconds causes game to run
		private void Timer_Tick(object sender, EventArgs e)
		{
			NextGeneration();
		}

		private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
		{
			// Calculate the width and height of each cell in pixels
			// CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
			int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
			// CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
			int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

			// A Pen for drawing the grid lines (color, width)
			//width is not exactly 1 pixel but think of it like that, bigger = thicker lines
			Pen gridPen = new Pen(gridColor, 1);

			// A Brush for filling living cells interiors (color)
			//abstract base class; SolidBrush, TextureBrush (Bitmap), Linear Gradient
			Brush cellBrush = new SolidBrush(cellColor);

			// Iterate through the universe in the y, top to bottom
			for (int y = 0; y < universe.GetLength(1); y++)
			{
				// Iterate through the universe in the x, left to right
				for (int x = 0; x < universe.GetLength(0); x++)
				{
					// A rectangle to represent each cell in pixels
					/////RectangleF turns rectangle into float object
					Rectangle cellRect = Rectangle.Empty;
					cellRect.X = x * cellWidth;
					cellRect.Y = y * cellHeight;
					cellRect.Width = cellWidth;
					cellRect.Height = cellHeight;

					//font&string info for neighborcount
					Font font = new Font("Arial", 20);
					StringFormat stringFormat = new StringFormat();
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;

					// Fill the cell with a brush if alive
					if (universe[x, y] == true)
					{
						e.Graphics.FillRectangle(cellBrush, cellRect);
					}
					if (isGridVisible)
					{
						// Outline the cell with a pen
						e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
					}
					if (isNeighborVisible)//display neighborcount in cells
					{	
						int neighborcount;
						if (isFinite)
						{
							neighborcount = CountNeighborsFinite(x, y);
						}
						else
						{
							neighborcount = CountNeighborsToroidal(x, y);
						}
						if (neighborcount > 0)
						{ e.Graphics.DrawString(neighborcount.ToString(), font, Brushes.Turquoise, cellRect, stringFormat); }
						else
						{ continue; }
					}
				}
			}
			//HUD
			if (isHUDVisible)
            {
				string theHUD = "Generations: " + generations + "\nCells " + StripStatusLabelAlive;
				Color myColor = Color.FromArgb(133, 0, 0);
				Brush HUDBrush = new SolidBrush(myColor);
				Font HUDfont = new Font("Times New Roman", 20);
				StringFormat HUDstringFormat = new StringFormat();
				HUDstringFormat.Alignment = StringAlignment.Near;
				HUDstringFormat.LineAlignment = StringAlignment.Far;
				
				e.Graphics.DrawString(theHUD, HUDfont, HUDBrush, graphicsPanel1.ClientRectangle, HUDstringFormat);
				//create transparency color using static from ARGB; then create color, then create brush from that color
				HUDBrush.Dispose();
            }

			//// Cleaning up pens and brushes
			////not the same as delete but it signifies done w it
			gridPen.Dispose();
			cellBrush.Dispose();
		}
		private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
		{
			// If the left mouse button was clicked
			if (e.Button == MouseButtons.Left)
			{
				// Calculate the width and height of each cell in pixels
				/////TODO: Turn to floats to make program look better
				int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
				int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

				// Calculate the cell that was clicked in
				/////calculating the index of the cell
				// CELL X = MOUSE X / CELL WIDTH
				int x = e.X / cellWidth;
				// CELL Y = MOUSE Y / CELL HEIGHT
				int y = e.Y / cellHeight;

				// Toggle the cell's state
				universe[x, y] = !universe[x, y];
				HowManyAlive();
				// Tell Windows you need to repaint
				///////line called the most thruout program
				graphicsPanel1.Invalidate();
			}
		}
		/// never call paint directly
		/// never put invalidate within the paint

		#region SettingsTabClickEvents - Colors, Reset, Reload
		private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = cellColor;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				cellColor = dlg.Color;
				graphicsPanel1.Invalidate();
			}
		}

		private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.Color = gridColor;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				gridColor = dlg.Color;
				graphicsPanel1.Invalidate();
			}
		}

		//grid x10 is like the "big grid" of it, like the shape of tic tac toe whereas the grid is every cell outline
		private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();

			dlg.Color = graphicsPanel1.BackColor;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				graphicsPanel1.BackColor = dlg.Color;
				graphicsPanel1.Invalidate();
			}

		}
		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reset();
			graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
			gridColor = Properties.Settings.Default.gridColor;
			cellColor = Properties.Settings.Default.cellColor;
		}

		private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.Reload();
			graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
			gridColor = Properties.Settings.Default.gridColor;
			cellColor = Properties.Settings.Default.cellColor;
		}
		#endregion SettingsTabClickEvents - Colors, Reset, Reload

		#region Randomize - Functions and Click Events
		private void RandomizeFromTime()
		{
			Random rand = new Random();
			for (int y = 0; y < universe.GetLength(1); y++)
			{
				for (int x = 0; x < universe.GetLength(0); x++)
				{
					if (rand.Next(0, 2) == 1)
					{ universe[x, y] = true; }
					else { universe[x, y] = false; }
				}
			}
			HowManyAlive();
			graphicsPanel1.Invalidate();
		}
		private void RandomizeFromSeed(int seed)
		{
			Random rand = new Random(seed);
			for (int y = 0; y < universe.GetLength(1); y++)
			{
				for (int x = 0; x < universe.GetLength(0); x++)
				{
					if (rand.Next(0, 2) == 1)
					{ universe[x, y] = true; }
					else { universe[x, y] = false; }
				}
			}
			HowManyAlive();
			graphicsPanel1.Invalidate();
		}
		private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RandomizeFromSeed_Modal_Dialog dlg = new RandomizeFromSeed_Modal_Dialog();
			dlg.SeedInteger = 0;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				int seed = dlg.SeedInteger;
				RandomizeFromSeed(seed);
				graphicsPanel1.Invalidate();
			}
		}
		private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RandomizeFromTime();
		}
		#endregion Randomize - Functions and Click Events

		#region FileTab - New, Open, Save, Exit
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close(); //destroying the main window to shut down program
		}
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int y = 0; y < universe.GetLength(1); y++)
			{
				// Iterate through the universe in the x, left to right
				for (int x = 0; x < universe.GetLength(0); x++)
				{
					universe[x, y] = false;
				}
			}
			generations = 0;
			toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
			HowManyAlive();
			graphicsPanel1.Invalidate();
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "All Files|*.*|Cells|*.cells";
			dlg.FilterIndex = 2; dlg.DefaultExt = "cells";

			if (DialogResult.OK == dlg.ShowDialog())
			{
				StreamWriter writer = new StreamWriter(dlg.FileName);
				writer.WriteLine("!Game of Life Pattern");

				for (int y = 0; y < universe.GetLength(1); y++)
				{
					String currentRow = string.Empty;

					for (int x = 0; x < universe.GetLength(0); x++)
					{
						if (universe[x, y] == true)
						{ currentRow += 'O'; }
						else { currentRow += '.'; }
					}
					writer.WriteLine(currentRow);
				}
				writer.Close();
			}
		}
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "All Files|*.*|Cells|*.cells";
			dlg.FilterIndex = 2;
			if (DialogResult.OK == dlg.ShowDialog())
			{
				StreamReader reader = new StreamReader(dlg.FileName);
				int maxWidth = 0;
				int maxHeight = 0;
				while (!reader.EndOfStream)
				{
					string row = reader.ReadLine();
					if (row.Contains("!")) { continue; }
					else
					{
						maxHeight++;
						if (row.Length > maxWidth) { maxWidth = row.Length; }
						else { continue; }
					}
				}
				universe = new bool[maxWidth, maxHeight];
				scratchPad = new bool[maxWidth, maxHeight];

				reader.BaseStream.Seek(0, SeekOrigin.Begin);

				int yPos = 0;
				while (!reader.EndOfStream)
				{
					string row = reader.ReadLine();

					if (row.Contains("!")) { continue; }
					else
					{
						for (int xPos = 0; xPos < row.Length; xPos++)
						{
							if (row[xPos] == 'O')
							{ universe[xPos, yPos] = true; }
							else { universe[xPos, yPos] = false; }
						}
					}
					yPos++;
				}
				toolStripStatusLabelGenerations.Text = "Generations = 1";
				reader.Close();
			}
		}
		#endregion FileTab - New, Open, Save, Exit

		#region ToolStrip - Start, Pause, Forward 1 Gen
		private void toolStripButton1_Click(object sender, EventArgs e) //start
		{
			timer.Enabled = true; //turn on/run
			NextGeneration();
		}
		private void toolStripButton2_Click(object sender, EventArgs e) //pause
		{
			timer.Enabled = false; //turn off.stop
		}
		private void Forward1Gen_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 1; i++)
			{
				NextGeneration();
			}
		}
		#endregion ToolStrip - Start, Pause, Forward 1 Gen

		#region View Tab - Toggle HUD, NeighborCount in Cells, Grid, Boundary Type
		private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isHUDVisible)
			{ isHUDVisible = false; }
            else 
			{ isHUDVisible = true; }
			graphicsPanel1.Invalidate();
		}
		private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isNeighborVisible)
			{ isNeighborVisible = false; }
			else
			{ isNeighborVisible = true; }
			graphicsPanel1.Invalidate();
		}
		private void gridToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (isGridVisible)
			{ isGridVisible = false; }
			else
			{ isGridVisible = true; }
			graphicsPanel1.Invalidate();
		}
		private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			isFinite = false;
		}
		private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			isFinite = true;
		}
        #endregion
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.BackgroundColor = graphicsPanel1.BackColor;
			//Properties.Settings.Default.NewHeight = universe.GetLength(Width);
			//Properties.Settings.Default.NewWidth = universe.GetLength(0);
			Properties.Settings.Default.cellColor = cellColor;
			Properties.Settings.Default.gridColor = gridColor;
			Properties.Settings.Default.Save();
		}
		private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ChangeSize_Modal_Dialog dlg = new ChangeSize_Modal_Dialog();

			/*int uniHeight = 0;
			int uniWidth = 0;*/
			//int timing = 10;
			int x = 15;
			int y = 15;
			dlg.NewWidth = Width;
			dlg.NewHeight = Height;
			//dlg.NewTime = timer;
			dlg.Apply += new ChangeSize_Modal_Dialog.ApplyEventHandler(dlg_Apply);
			if (DialogResult.OK == dlg.ShowDialog())
			{
				if (dlg.NewHeight > universe.GetLength(1) || dlg.NewHeight < universe.GetLength(1))
                {
					y = dlg.NewHeight;
                }
				if (dlg.NewWidth > universe.GetLength(0) || dlg.NewWidth < universe.GetLength(0))
				{
					x = dlg.NewWidth;
				}
				/*if (timing > dlg.NewTime || timing < dlg.NewTime)
				{
					timing = dlg.NewTime;
					timer.Interval = timing;
				}
				else (timer.Interval = proper);*/
				/*uniHeight = dlg.NewHeight;
				uniWidth = dlg.NewWidth;
				timing = dlg.NewTime;*/


				universe = new bool[x, y];
				scratchPad = new bool[x, y];
				//timer.Interval = timing;
				graphicsPanel1.Invalidate();
			}
		}

		//experiments creating new modal dialog box for size adjustment
		void dlg_Apply(object sender, ApplyEventArgs e)
        {
			int x = e.NewWidth;
			int y = e.NewHeight;
			int z = e.NewTime;
        }


    }
}
