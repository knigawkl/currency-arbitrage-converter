using System.Collections.Generic;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Drawing;
using System.Drawing.Imaging;

namespace GWhub
{
    public class Digraph
    {
        static readonly int WIDTH = 1000;

        public List<CurrencyVertex> nodes = new List<CurrencyVertex>();
        public List<ExchangeEdge> edges = new List<ExchangeEdge>();

        public Graph Draw()
        {
            var graphImg = new Graph();
            AddNodes(graphImg);
            AddEdges(graphImg);
            return graphImg;
        }

        private void AddNodes(Graph graphImg)
        {
            foreach (var node in nodes)
            {
                graphImg.AddNode(node.Symbol).Attr.FillColor = Microsoft.Msagl.Drawing.Color.Yellow;
            }
        }

        private void AddEdges(Graph graphImg)
        {
            foreach (var edge in edges)
            {
                var ed = graphImg.AddEdge(edge.StartVertex.Symbol,
                    edge.Weight.ToString(),
                    edge.FinishVertex.Symbol);

                ed.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                ed.Attr.ArrowheadAtTarget = ArrowStyle.Normal;
            }
        }

        public void SaveGraphAsImg(string path)
        {
            Graph tmp = Draw();
            GraphRenderer renderer = new GraphRenderer(tmp);
            renderer.CalculateLayout();
            Bitmap bitmap = new Bitmap(WIDTH, (int)(tmp.Height * (WIDTH / tmp.Width)), PixelFormat.Format32bppPArgb);
            renderer.Render(bitmap);
            bitmap.Save(path);
        }
    }
}