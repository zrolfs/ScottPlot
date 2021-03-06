﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ScottPlot.Demo.PlotTypes
{
    class ErrorBar
    {
        public class ErrorBarsAsymmetric : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Scatter Plot with Asymmetric Errorbars";
            public string description { get; } = "Asymmetric X and Y error ranges can be supplied as optional double arrays for positive and/or negative error bars";

            public void Render(Plot plt)
            {
                Random rand = new Random(0);
                int pointCount = 20;

                // random data points
                double[] dataX = DataGen.Consecutive(pointCount);
                double[] dataY1 = DataGen.Sin(pointCount, offset: 6);
                double[] dataY2 = DataGen.Sin(pointCount, offset: 3);
                double[] dataY3 = DataGen.Sin(pointCount, offset: 0);

                // random errorbar sizes
                double[] errorYPositive = DataGen.RandomNormal(rand, pointCount);
                double[] errorXPositive = DataGen.RandomNormal(rand, pointCount);
                double[] errorYNegative = DataGen.RandomNormal(rand, pointCount);
                double[] errorXNegative = DataGen.RandomNormal(rand, pointCount);

                // plot different combinations of errorbars
                plt.PlotErrorBars(dataX, dataY1, errorXPositive, errorXNegative, errorYPositive, errorYNegative, label: "Asymmetric X and Y errors");
                plt.PlotErrorBars(dataX, dataY2, errorXPositive, null, errorYPositive, null, label: "Positive errors only");
                plt.PlotErrorBars(dataX, dataY3, null, errorXNegative, null, errorYNegative, label: $"Negative errors only");

                plt.Title("Error Bars with Asymmetric X and Y Values");
                plt.Grid(false);
                plt.Legend();
            }
        }
    }
}
