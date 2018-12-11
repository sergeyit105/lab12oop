using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab12
{
    class CEmblem : CFigure
    {
        private int _sideA;
        private int _sideB;
        private int _side;
        private int _radius;
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value >= 200 ? 200 : value;
                _radius = value <= 5 ? 5 : value;
            }
        }
        public int Side
        {
            get
            {
                return _side;
            }
            set
            {
                _side = value >= 200 ? 200 : value;
                _side = value <= 5 ? 5 : value;
            }
        }
        public int SideA
        {
            get
            {
                return _sideA;
            }
            set
            {
                _sideA = value >= 200 ? 200 : value;
                _sideA = value <= 5 ? 5 : value;
            }
        }
        public int SideB
        {
            get
            {
                return _sideB;
            }
            set
            {
                _sideB = value >= 200 ? 200 : value;
                _sideB = value <= 5 ? 5 : value;
            }
        }
        public CEmblem(Graphics graphics, int X, int Y, int SideA, int SideB)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.SideA = SideA;
            this.SideB = SideB;
            this.Side = Side;
            this.Radius = Radius;

        }

        protected override void Draw(Pen pen)
        {
            Rectangle rectangle = new Rectangle(X - SideA / 2, Y - SideB / 2, SideA, SideB + 40);
            graphics.DrawRectangle(pen, rectangle);

            double r = (Side / 2) / Math.Sin(Math.PI / 3);
            Point p1 = new Point(X+50, (Y+68) - (int)r);
            Point p2 = new Point((X+140) - (int)(r * Math.Cos(Math.PI / 6)),
            (Y + 20) + (int)(r * Math.Sin(Math.PI / 6)));
            Point p3 = new Point((X+47) + (int)(r * Math.Cos(Math.PI / 6)),
            (Y-27) + (int)(r * Math.Sin(Math.PI / 6)));
            Point[] triangle = { p1, p2, p3 };
            graphics.DrawPolygon(pen, triangle);

            Rectangle rectangle2 = new Rectangle((X + 143) - Radius, (Y - 20) - Radius, 2 * Radius + 80, 2 * Radius + 80);
            graphics.DrawEllipse(pen, rectangle2);
        }
        override public void Expand(int dX)
        {
            Hide();
            SideA = SideA + dX;
            SideB = SideB + dX;
            Side = Side + dX;
            Radius = Radius + dX;
            Show();
        }
        override public void Collapse(int dX)
        {
            Hide();
            SideA = SideA - dX;
            SideB = SideB - dX;
            Side = Side - dX;
            Radius = Radius - dX;

            Show();
        }
    }
}

