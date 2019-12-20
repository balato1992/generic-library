using System;
using System.Drawing;

namespace TestSamples.Rpn
{
    // https://stackoverflow.com/questions/423898/postfix-notation-to-expression-tree
    public class VisualizingNode
    {
        public VisualizingNode(string value) : this(value, null, null) { }

        public VisualizingNode(string value, VisualizingNode left, VisualizingNode right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public string Value;
        public VisualizingNode Left;
        public VisualizingNode Right;

        public Bitmap ToBitmap()
        {
            Font font = new Font("Arial", 8);
            Bitmap flag = new Bitmap(800, 600);


            Size valueSize;
            using (Graphics g = Graphics.FromImage(flag))
            {
                var tempSize = g.MeasureString(Value, font);
                valueSize = new Size((int)tempSize.Width + 4, (int)tempSize.Height + 4);
            }

            Bitmap bitmap;
            Color valueColor = Color.LightPink;
            if (Left == null && Right == null)
            {
                bitmap = new Bitmap(valueSize.Width, valueSize.Height);
                valueColor = Color.LightGreen;
            }
            else
            {
                using (var leftBitmap = Left.ToBitmap())
                using (var rightBitmap = Right.ToBitmap())
                {
                    int subNodeHeight = Math.Max(leftBitmap.Height, rightBitmap.Height);
                    bitmap = new Bitmap(
                        leftBitmap.Width + rightBitmap.Width + valueSize.Width,
                        valueSize.Height + 32 + subNodeHeight);

                    using (var g = Graphics.FromImage(bitmap))
                    {
                        int baseY = valueSize.Height + 32;

                        int leftTop = baseY; // + (subNodeHeight - leftBitmap.Height) / 2;
                        g.DrawImage(leftBitmap, 0, leftTop);

                        int rightTop = baseY; // + (subNodeHeight - rightBitmap.Height) / 2;
                        g.DrawImage(rightBitmap, bitmap.Width - rightBitmap.Width, rightTop);

                        g.DrawLine(Pens.Black, bitmap.Width / 2 - 4, valueSize.Height, leftBitmap.Width / 2, leftTop);
                        g.DrawLine(Pens.Black, bitmap.Width / 2 + 4, valueSize.Height, bitmap.Width - rightBitmap.Width / 2, rightTop);
                    }
                }
            }

            using (var g = Graphics.FromImage(bitmap))
            {
                float x = (bitmap.Width - valueSize.Width) / 2;
                using (var b = new SolidBrush(valueColor))
                    g.FillRectangle(b, x, 0, valueSize.Width - 1, valueSize.Height - 1);
                g.DrawRectangle(Pens.Black, x, 0, valueSize.Width - 1, valueSize.Height - 1);
                g.DrawString(Value, font, Brushes.Black, x + 1, 2);
            }

            return bitmap;
        }
    }
}
