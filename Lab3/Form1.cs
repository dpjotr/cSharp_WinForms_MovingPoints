using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Lab3
{
    public partial class Form1 : Form
    {
        Point iPointToDrag;
        bool bDragFlag;
        bool movementButtonFlag;
        bool chaosMovementButtonFlag;


        enum eLineType { None, Curved, Broken, Beiser, Painted };
        eLineType currentShape;

        int formWidth, formHeight;

        internal int radius; internal int GetRadius() { return radius; }

        System.Windows.Forms.Timer moveTimer;
        int deltaMovementX;
        int deltaMovementY;
        int move;

        Pen myPen;
        internal string GetPenWidth() { return myPen.Width.ToString(); }
        internal string GetPenColor() { return myPen.Color.ToString(); }

        Color myColorLine;  internal String GetPointColor() { return myColorLine.ToString(); }

        Brush myBrush;

        
        List<Point> arPoints;
        List<myPointDelta> deltaMovement;

        void AllFalse()
        {
            
            chaosMovementButtonFlag=false;
            
            movementButtonFlag = false;
         
        }
        public Form1()
        {
            
            InitializeComponent();
            DoubleBuffered = true;
            currentShape=eLineType.None ;
            radius = 10;
            myColorLine = Color.Bisque;
            myPen = new Pen(myColorLine);

            myBrush = Brushes.Red;
            bDragFlag = false;
            formWidth = this.Width;
            formHeight = this.Height;
            arPoints = new List<Point>();
            deltaMovement = new List<myPointDelta>();
            Paint += new PaintEventHandler(Form1_Paint);
            MouseDown += button1_MouseDown;

            
            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 30;
            moveTimer.Tick += new EventHandler(TimerTickHandler);
            move = 1;
            deltaMovementX = deltaMovementY=move;

            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            MouseUp += MouseUpper;

            MouseMove += new MouseEventHandler(MouseMoving);
  
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            try
            {
                Point[] arrPoints = arPoints.ToArray();
                {
                    foreach (var x in arPoints)
                    {
                        int xCentered = x.X - radius;
                        int yCentered = x.Y - radius;

                        g.FillEllipse(myBrush, new Rectangle(xCentered, yCentered, radius * 2, radius * 2));

                    }
                }
                switch (currentShape)
                {
                    case eLineType.Curved: g.DrawCurve(myPen, arrPoints); break;
                    case eLineType.Broken: g.DrawLines(myPen, arrPoints); break;
                    case eLineType.Beiser: g.DrawBeziers(myPen, arrPoints); break;
                    case eLineType.Painted: g.FillClosedCurve(Brushes.ForestGreen, arrPoints); break;
                    default: break;
                }
            }
            catch (Exception) { g.Clear(System.Drawing.SystemColors.ActiveCaption); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentShape = eLineType.Broken;
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentShape = eLineType.Curved;
            Refresh();
        }

        void ClearScreen()
        {
            arPoints = new List<Point>();
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void normalizePoints()
        {
            for (int i = 0; i < arPoints.Count; i++)
            {
                deltaMovement[i].x = move;
                deltaMovement[i].y = move;
            }
        }

        private void RandomizePoints()
        {
            for (int i = 0; i < arPoints.Count; i++)
            {
                Random r = new Random();
                deltaMovement[i].x = r.Next(move) * (i % 2 == 0 ? 1 : -1) - i == 0 ? 5 : i;
                deltaMovement[i].y = r.Next(move) * (i % 2 == 0 ? 1 : -1) - i == 0 ? 5 : i;
                Point temp = new Point(arPoints[i].X + deltaMovement[i].x, arPoints[i].Y + deltaMovement[i].y);
                arPoints[i] = temp;
            }
        }

        private void StartNormalMovement()
        {
            AllFalse();
            movementButtonFlag = true;
            this.movementButton.Text = "Chaos movement";
            normalizePoints();
            moveTimer.Start();

        }

        private void startChaoticMovement()
        {
            AllFalse();
            chaosMovementButtonFlag = true;
            this.movementButton.Text = "Stop movement";
            RandomizePoints();
            moveTimer.Start();
        }

        private void stopAnyMovementAndNormalize()
        {
            moveTimer.Stop();
            AllFalse();
            this.movementButton.Text = "Start movement";
            normalizePoints();
        }


        //CommonMovement() changes points movement mode, 3 options are available:
        //Calm movement, Chaotic movement, No movement
        //Options can be changed from main window of GUI or by pressing of Space button
 
        private void CommonMovement()
        {

            if (movementButtonFlag == false && chaosMovementButtonFlag == false)
            {
                StartNormalMovement();
            }
            else if (movementButtonFlag == true)
            {
                startChaoticMovement();
            }
            else if (chaosMovementButtonFlag == true)
            {
                stopAnyMovementAndNormalize();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            CommonMovement();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            PropertiesForm f = new PropertiesForm(this);
            f.Owner = this;
            f.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllFalse();
            this.movementButton.Text = "Start movement";
            
            currentShape = eLineType.None;
        }



        void button1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < arPoints.Count ; i++)
            {
                if (((arPoints[i].X-radius < e.Location.X) && (arPoints[i].X + 2 * radius > e.Location.X)) &&
                    ((arPoints[i].Y-radius < e.Location.Y) && (arPoints[i].Y + 2 * radius > e.Location.Y))&&
                    (!movementButtonFlag && !chaosMovementButtonFlag))
                {
                    bDragFlag =true;
                    Cursor = Cursors.Hand;
                    iPointToDrag = arPoints[i];
                    arPoints.Remove(iPointToDrag);
                    
                    Refresh();
                    return;
                }

            }

            

                arPoints.Add(new Point(e.Location.X, e.Location.Y));
                deltaMovement.Add(new myPointDelta(deltaMovementX, deltaMovementY));
                Refresh();
            
        }

        void MouseMoving(object sender, MouseEventArgs e)
        {
            if (bDragFlag && movementButtonFlag == false && chaosMovementButtonFlag == false)
            {
                
                iPointToDrag.X = e.Location.X;
                iPointToDrag.Y = e.Location.Y;                               

            }
        }

        void MouseUpper(object sender, MouseEventArgs e)
        {
            if (bDragFlag)
            {
                Cursor = Cursors.Cross;
                arPoints.Add(iPointToDrag);
                bDragFlag = false;
                Refresh();
            }
        }


        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
             switch (e.KeyCode)
              {
                case (Keys.Space):
                    CommonMovement(); break;
                case (Keys.Escape):
                    ClearScreen(); break;
                case (Keys.Oemplus):
                case (Keys.Add):
                    DoubleSpeedIncrease(); break;
                case (Keys.OemMinus):
                case (Keys.Subtract):
                    DoubleSpeedDecrease(); break;
                default:break;
              }

               e.Handled = true;
          
        }

        void DoubleSpeedIncrease()
        {
            for (int i = 0; i < deltaMovement.Count; i++)
            {
                deltaMovement[i].x = deltaMovement[i].x == 0 ? 1 : deltaMovement[i].x * 2;
                deltaMovement[i].y = deltaMovement[i].y == 0 ? 1 : deltaMovement[i].y * 2;
            }
        }
        void DoubleSpeedDecrease()
        {
            for (int i = 0; i < deltaMovement.Count; i++)
            {
                deltaMovement[i].x /= 2;
                deltaMovement[i].y /= 2;
            }

        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
     
            if (movementButtonFlag==false&&chaosMovementButtonFlag==false)
                switch (keyData)
                { 
                    case Keys.Up:
                        for (int i = 0; i < deltaMovement.Count; i++)
                            if (arPoints[i].Y-radius > 0) arPoints[i] = new Point(arPoints[i].X, arPoints[i].Y-1);   Refresh();
                        break;
                    case Keys.Down:
                        for (int i = 0; i < deltaMovement.Count; i++)
                            if (arPoints[i].Y+radius < this.ClientSize.Height) arPoints[i] = new Point(arPoints[i].X, arPoints[i].Y + 1); Refresh();
                        break;
                    case Keys.Left:
                        for (int i = 0; i < deltaMovement.Count; i++)
                            if (arPoints[i].X-2*radius > this.buttonPannel.Width) arPoints[i] = new Point(arPoints[i].X - 1, arPoints[i].Y); Refresh();
                        break;
                    case Keys.Right:
                        for (int i = 0; i < deltaMovement.Count; i++)
                            if (arPoints[i].X +  radius < this.ClientSize.Width) arPoints[i] = new Point(arPoints[i].X + 1, arPoints[i].Y); Refresh();
                        break;
                }
            else
                switch (keyData)
                {
                    case Keys.Up:
                        for (int i = 0; i<arPoints.Count; i++)
                        {
                            deltaMovement[i].y--;
                        }
                        break;
                    case Keys.Down:
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            deltaMovement[i].y++;
                        }
                        break;
                    case Keys.Left:
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            deltaMovement[i].x--;
                        }
                        break;
                    case Keys.Right:
                        for (int i = 0; i < arPoints.Count; i++)
                        {
                            deltaMovement[i].x++;
                        }
                        break;
                }




            return base.ProcessCmdKey(ref msg, keyData);
        }


        void TimerTickHandler(object sender, EventArgs e)
        {
        
            for (int i = 0; i < arPoints.Count; i++)
            {
  
                    if ((arPoints[i].X ) >= formWidth - 2 * radius ||
                            (arPoints[i].X ) <= this.buttonPannel.Width + 2 * radius) deltaMovement[i].x = -deltaMovement[i].x;

                    if ((arPoints[i].Y) >= formHeight - 4 * radius || 
                            (arPoints[i].Y + deltaMovement[i].y) <= 0 + radius) deltaMovement[i].y = -deltaMovement[i].y;

                    Point temp = new Point(arPoints[i].X + deltaMovement[i].x, arPoints[i].Y + deltaMovement[i].y);
                    arPoints[i] = temp;
                    Refresh();

            }
        }

        private void BesierButton_Click_1(object sender, EventArgs e)
        {
            if ((arPoints.Count - 1) % 3 == 0 && arPoints.Count > 2)
            {
                currentShape = eLineType.Beiser;
                Refresh();
            }
            else
            {
                int temp = 0;
                while ((arPoints.Count - 1 + temp) % 3 != 0 || (arPoints.Count-1+temp) < 3) temp++;
                string message = $"Add {temp} more points";
                string caption = "Action can not be done";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
   
            }
            
        }

        private void PaintedButton_Click_1(object sender, EventArgs e)
        {
            currentShape = eLineType.Painted;
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            BorderCheck();
            Refresh();


        }
        //BorderCheck() moves points away from border
        //in order to prevent sinking of points during window resize
       
        private void BorderCheck()
        {
            formWidth = this.ClientSize.Width;
            formHeight = this.ClientSize.Height;
            try
            {
                for (int i = 0; i < arPoints.Count; i++)
                {
                    int height = arPoints[i].Y;
                    int width = arPoints[i].X;

                    if (height + radius > formHeight) height = formHeight - radius * 3;
                    if (width +  radius > formWidth) width = formWidth - radius * 3;
                    Point temp = new Point(width, height);
                    arPoints[i] = temp;
                    

                }
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }
        }


        internal void ChangeRadius()
        {
            if (radius < 20) radius += 5;
            else radius = 5;
            Refresh();
        }
        internal void ChangePointColor()
        {
            if (myBrush != Brushes.Red) myBrush=Brushes.Red;
            else myBrush=Brushes.Black;
            Refresh();
        }
        internal void ChangeLineColor()
        {
            if (myPen.Color != Color.Bisque) myPen.Color = Color.Bisque;
            else myPen.Color = Color.Black;
            Refresh();
        }
        internal void ChangeLineWidth()
        {
            if (myPen.Width != 1) myPen.Width = 1;
            else myPen.Width = 3;
            Refresh();
        }

    }
    class myPointDelta { public int x, y; public myPointDelta(int X, int Y) { x = X; y = Y; } }

}
