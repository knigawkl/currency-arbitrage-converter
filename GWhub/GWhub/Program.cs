using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GWhub
{
    static class Program
    {
        static readonly string INPUT_PATH = @"D:\Desktop\GWhub\2018Z_AISD_proj_ind_gr9\input\input.txt";
        static readonly string IMG_PATH = @"D:\Desktop\GWhub\2018Z_AISD_proj_ind_gr9\output\output.png";

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            Parser p = new Parser();
            DirectedGraph graph = p.Parse(INPUT_PATH);
            graph.Draw();
            graph.SaveGraphAsImg(IMG_PATH);
        }
    }
}
