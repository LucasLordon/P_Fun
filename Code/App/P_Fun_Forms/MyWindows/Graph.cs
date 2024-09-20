﻿using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    public partial class Graph : System.Windows.Forms.Form
    {
        readonly ScottPlot.Plottables.Crosshair CH;

        public Graph()
        {
            InitializeComponent();

            ImportData();
            ConfigGraph();

            CH = formsPlot1.Plot.Add.Crosshair(0, 0);
            CH.TextBackgroundColor = CH.HorizontalLine.Color;

            formsPlot1.MouseMove += FormsPlot1_MouseMove;
            formsPlot1.MouseDown += FormsPlot1_MouseDown;

            formsPlot1.Refresh();
        }

        private void Graph_Load(object sender, EventArgs e)
        {

        }

        private void ImportData()
        {
            double[] dataX = { 1, 2, 3, 4, 5 };
            double[] dataY = { 1, 4, 9, 16, 25 };
            formsPlot1.Plot.Add.Scatter(dataX, dataY);

            double[] dataX1 = { 1, 2, 3, 4, 5 };
            double[] dataY1 = { 3, 7, 12, 19, 28 };
            formsPlot1.Plot.Add.Scatter(dataX1, dataY1);
        }

        private void ConfigGraph()
        {
            formsPlot1.Plot.XLabel("Date");
            formsPlot1.Plot.YLabel("Nombres de cas covid");
        }
        private void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            Pixel mousePixel = new(e.X, e.Y);
            Coordinates mouseCoordinates = formsPlot1.Plot.GetCoordinates(mousePixel);
            this.Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3}";
            CH.Position = mouseCoordinates;
            CH.VerticalLine.Text = $"{mouseCoordinates.X:N3}";
            CH.HorizontalLine.Text = $"{mouseCoordinates.Y:N3}";
            formsPlot1.Refresh();
        }
        private void FormsPlot1_MouseDown(object sender, MouseEventArgs e)
        {
            Pixel mousePixel = new(e.X, e.Y);
            Coordinates mouseCoordinates = formsPlot1.Plot.GetCoordinates(mousePixel);
            Text = $"X={mouseCoordinates.X:N3}, Y={mouseCoordinates.Y:N3} (mouse down)";
        }
    }
}