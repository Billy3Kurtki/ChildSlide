using System;
using System.Media;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Kazakov_Kirill_PRI_120_lab_10
{
    public partial class Form1 : Form
    {

        // вспомогательные переменные - в них будут хранится обработанные значения,
        // полученные при перетаскивании ползунков пользователем
        double _translateX = 0, _translateY = 0, _translateZ = -20, zoom = 1;
        double _translateHumanX = 0, _translateHumanY = 0, _translateHumanZ = -20;

        private int count_elements;
        private int Iter = 64;
        private double Angle = 2 * Math.PI / 64;
        private double[,] GeometricTorArray = new double[64, 3];
        private double[,,] ResaultTorGeometric = new double[64, 64, 3];
        private float[] _abmbientIntesive = { 1, 1, 1, 1 };
        Explosion explosion = new Explosion(40, 15, -7, 300, 500);
        float _globalTime = 0;
        float lastTime = 0;

        float rotateAngle = 0;

        private anEngine ProgrammDrawingEngine;

        // оси вращения
        int _rotateX = -80, _rotateY = 0, _rotateZ = 0;

        int _rotateFractalZ = 0;

        bool showFractal = false;
        bool showHuman = false;
        bool isAnimating = false;
        bool needToStopAnim = false;
        bool isDay = true;
        bool boomIsOn = true;

        uint bg1 = 0;
        uint bg2 = 0;
        uint bg3 = 0;
        uint bg4 = 0;
        uint bg1night = 0;
        uint bg2night = 0;
        uint bg3night = 0;
        uint bg4night = 0;

        uint[] arrayGirlyanda = new uint[3];

        uint skyDay = 0;
        uint skyNight = 0;
        uint fractal = 0;
        uint fractalDark = 0;

        anModelLoader Model = null;

        SoundPlayer soundPlayer;
        bool soundOn = true;

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация бибилиотеки glut
            Glut.glutInit();
            // инициализация режима экрана
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // инициализация библиотеки OpenIL
            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // установка цвета очистки экрана (RGBA)
            Gl.glClearColor(255, 255, 255, 1);
            /*Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_DEPTH_TEST);*/
            // установка порта вывода
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы
            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, _abmbientIntesive);
            // очистка матрицы
            Gl.glLoadIdentity();

            // установка перспективы
            Glu.gluPerspective(45, (float)AnT.Width / (float)AnT.Height, 0.1, 400);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            /*ObjectDrawer.DrawEarth();*/
            bg1 = TextureBuilder.LoadTexture("bg1.jpg");
            bg2 = TextureBuilder.LoadTexture("bg2.jpg");
            bg3 = TextureBuilder.LoadTexture("bg3.jpg");
            bg4 = TextureBuilder.LoadTexture("bg4.jpg");

            bg1night = TextureBuilder.LoadTexture("bg1night.jpg");
            bg2night = TextureBuilder.LoadTexture("bg2night.jpg");
            bg3night = TextureBuilder.LoadTexture("bg3night.jpg");
            bg4night = TextureBuilder.LoadTexture("bg4night.jpg");

            arrayGirlyanda[0] = TextureBuilder.LoadTexture("gif1.jpg");
            arrayGirlyanda[1] = TextureBuilder.LoadTexture("gif2.jpg");
            arrayGirlyanda[2] = TextureBuilder.LoadTexture("gif3.jpg");

            fractal = TextureBuilder.LoadTexture("fractal.jpg");
            fractalDark = TextureBuilder.LoadTexture("fractalDark.jpg");

            skyDay = TextureBuilder.LoadTexture("day.jpg");
            skyNight = TextureBuilder.LoadTexture("night.jpg");

            Model = new anModelLoader();
            Model.LoadModel("kid.ase");

            ProgrammDrawingEngine = new anEngine(AnT.Width, AnT.Height, AnT.Width, AnT.Height);

            CalculateRotationBody();
            RenderTimer.Start();
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                if (_translateY - 1 < 110 && _translateY - 1 > -110)
                {
                    if (_translateY - 1 < -48 && _translateY - 1 > -83 && _translateX > -20 && _translateX < -11)
                    {
                        _translateZ -= 1;
                    }
                    if (_translateY - 1 < -91 && _translateY - 1 > -99 && _translateX > -20 && _translateX < -11 && _translateZ < -15)
                    {
                        _translateZ += 4;
                    }
                    Console.WriteLine($"{_translateX} {_translateY} {_translateZ}");
                    _translateY -= 1;
                }

            if (e.KeyCode == Keys.S)
                if (_translateY + 1 < 110 && _translateY + 1 > -110)
                {
                    if (_translateY + 1 < -48 && _translateY + 1 > -83 && _translateX > -20 && _translateX < -11)
                    {
                        _translateZ += 1;
                    }
                    if (_translateY - 1 < -91 && _translateY - 1 > -99 && _translateX > -20 && _translateX < -11 && _translateZ < -15)
                    {
                        _translateZ -= 4;
                    }
                    _translateY += 1;
                }
            if (e.KeyCode == Keys.A)
                if (_translateX + 1 < 110 && _translateX + 1 > -110)
                    _translateX += 1;

            if (e.KeyCode == Keys.D)
                if (_translateX - 1 < 110 && _translateX - 1 > -110)
                    _translateX -= 1;


            if (e.KeyCode == Keys.E)
                _rotateZ += 1;

            if (e.KeyCode == Keys.Q)
                _rotateZ -= 1;

            if (e.KeyCode == Keys.R)
                _rotateX -= 1;

            if (e.KeyCode == Keys.T)
                _rotateX += 1;

            if (e.KeyCode == Keys.F)
                _translateZ -= 1;

            if (e.KeyCode == Keys.G)
                _translateZ += 1;
        }

        private void Draw()
        {
            // очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glClearColor(255, 255, 255, 1);
            // очищение текущей матрицы
            Gl.glLoadIdentity();

            // помещаем состояние матрицы в стек матриц, дальнейшие трансформации затронут только визуализацию объекта
            Gl.glPushMatrix();
            // поворот по установленной оси
            Gl.glRotated(_rotateX, 1, 0, 0);
            Gl.glRotated(_rotateY, 0, 1, 0);
            Gl.glRotated(_rotateZ, 0, 0, 1);
            // производим перемещение в зависимости от значений, полученных при перемещении ползунков
            Gl.glTranslated(_translateX, _translateY, _translateZ);

            // и масштабирование объекта
            Gl.glScaled(zoom, zoom, zoom);

            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            if (showFractal)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(70, -70, -3);
                Gl.glRotated(_rotateFractalZ, 0, 0, 1);
                Gl.glTranslated(-70, 70, 3);
                AddFractal();
                Gl.glPopMatrix();
            }


            AddBackground();

            DrawGirlyanda();

            AddSky();
            explosion.Calculate(_globalTime);
            ObjectDrawer.DrawEarth();

            Gl.glPushMatrix();
            ObjectDrawer.DrawBorder();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            ObjectDrawer.DrawSandbox();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            ObjectDrawer.DrawSnake();
            Gl.glPopMatrix();



            /*Gl.glPushMatrix();
            ObjectDrawer.DrawBineryTree(1.5);
            Gl.glPopMatrix();*/

            if (Model != null)
            {
                if (showHuman)
                    if (!isAnimating)
                        DrawKid();
            }
            if (trackBar2.Value <= trackBar2.Maximum / 2)
                DrawOptionalRotationBody();

            ObjectDrawer.DrawSlide();

            double step = 99;
            for (double j = 0; j < 20; j += 5)
            {
                Gl.glPushMatrix();
                Gl.glColor3f(0.07f, 0.04f, 0.56f);
                Gl.glTranslated(15, step, j);
                Gl.glScaled(0.7, 0.1, 0.1);
                Glut.glutSolidCube(10);
                Gl.glPopMatrix();
                step -= 0.92;
            }

            DrawSlidingHuman(_globalTime);

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            _globalTime += (float)RenderTimer.Interval / 1000;
            Draw();
        }

        private void AddFractal()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            if (isDay)
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, fractal);
            else
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, fractalDark);
            Gl.glPushMatrix();
            Gl.glTranslated(70, -70, -3);
            /*Gl.glRotated(90, 1, 0, 0);*/
            Gl.glScaled(15, 15, 0);
            DrawPicture();
            Gl.glPopMatrix();
            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void AddSky()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            if (isDay)
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, skyDay);
            }
            else
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, skyNight);
            }

            Gl.glPushMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 130);
            /*Gl.glRotated(90, 1, 0, 0);*/
            Gl.glScaled(140, 140, 0);

            DrawPicture();

            Gl.glPopMatrix();
            Gl.glPopMatrix();

            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void AddBackground()
        {

            Gl.glEnable(Gl.GL_TEXTURE_2D);

            var angle = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            if (isDay)
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg1);
                            else
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg1night);
                            break;
                        }
                    case 1:
                        {
                            if (isDay)
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg2);
                            else
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg2night);
                            break;
                            break;
                        }
                    case 2:
                        {
                            if (isDay)
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg3);
                            else
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg3night);
                            break;
                        }
                    default:
                        {
                            if (isDay)
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg4);
                            else
                                Gl.glBindTexture(Gl.GL_TEXTURE_2D, bg4night);
                            break;
                        }
                }
                Gl.glPushMatrix();
                Gl.glRotated(angle, 0, 0, 1);
                Gl.glPushMatrix();
                Gl.glTranslated(0, -140, 0);
                Gl.glRotated(90, 1, 0, 0);
                Gl.glScaled(140, 140, 0);

                DrawPicture();

                Gl.glPopMatrix();
                Gl.glPopMatrix();

                angle += 90;
            }

            // отключаем режим текстурирования
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }

        private void DrawPicture()
        {
            // отрисовываем полигон
            Gl.glBegin(Gl.GL_QUADS);

            // указываем поочередно вершины и текстурные координаты
            Gl.glVertex3d(-1, 1, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(-1, -1, 0);
            Gl.glTexCoord2f(1, 0);
            Gl.glVertex3d(1, -1, 0);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(1, 1, 0);
            Gl.glTexCoord2f(0, 1);

            // завершаем отрисовку
            Gl.glEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (showFractal)
            {
                button1.Text = "Нарисовать фрактал на асфальте";
                showFractal = false;
                trackBar1.Visible = false;
            }
            else
            {
                button1.Text = "Стереть фрактал с асфальта";
                showFractal = true;
                trackBar1.Visible = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _rotateFractalZ = trackBar1.Value;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    {
                        button1.Visible = false;
                        trackBar1.Visible = false;
                        _translateX = -13;
                        _translateY = -30;
                        _translateZ = -15;
                        _rotateZ = 0;
                        _rotateX = -80;
                        break;
                    }
                case 1:
                    {
                        button1.Visible = false;
                        trackBar1.Visible = false;
                        _translateX = -8;
                        _translateY = 18;
                        _translateZ = -15;
                        _rotateZ = -30;
                        _rotateX = -80;
                        break;
                    }
                case 2:
                    {
                        button1.Visible = false;
                        trackBar1.Visible = false;
                        _translateX = -90;
                        _translateY = 40;
                        _translateZ = -15;
                        _rotateZ = 0;
                        _rotateX = -80;
                        break;
                    }
                case 3:
                    {
                        button1.Visible = true;
                        trackBar1.Visible = false;
                        _translateX = -14;
                        _translateY = 70;
                        _translateZ = -15;
                        _rotateZ = 90;
                        _rotateX = -80;
                        break;
                    }
            }
        }

        private void DrawRotationBody()
        {
            Gl.glScalef(0.1f, 0.1f, 0.1f);

            // устанавливаем размер точек равный 5
            Gl.glPointSize(5.0f);

            Gl.glColor3f(0.83f, 0.81f, 0.76f);

            // отрисовка тора по координатам, рассчитанным по параметрическим уравнениям

            Gl.glBegin(Gl.GL_QUADS); // режим отрисовки полигонов, состоящих из 4 вершин

            for (int ax = 0; ax < count_elements; ax++)
            {
                for (int bx = 0; bx < Iter; bx++)
                {
                    // вспомогательные переменные для более наглядного использования кода при расчете нормалей
                    double x1 = 0, x2 = 0, x3 = 0, x4 = 0, y1 = 0, y2 = 0, y3 = 0, y4 = 0, z1 = 0, z2 = 0, z3 = 0, z4 = 0;

                    // первая вершина
                    x1 = ResaultTorGeometric[ax, bx, 0];
                    y1 = ResaultTorGeometric[ax, bx, 1];
                    z1 = ResaultTorGeometric[ax, bx, 2];

                    if (ax + 1 < count_elements) // если текущий ax не последний
                    {

                        // берем следующую точку последовательности
                        x2 = ResaultTorGeometric[ax + 1, bx, 0];
                        y2 = ResaultTorGeometric[ax + 1, bx, 1];
                        z2 = ResaultTorGeometric[ax + 1, bx, 2];

                        if (bx + 1 < Iter - 1) // если текущий bx не последний
                        {

                            // берем следующую точку последовательности и следующий меридиан
                            x3 = ResaultTorGeometric[ax + 1, bx + 1, 0];
                            y3 = ResaultTorGeometric[ax + 1, bx + 1, 1];
                            z3 = ResaultTorGeometric[ax + 1, bx + 1, 2];

                            // точка, соотвествующуя по номеру только на соседнем меридиане
                            x4 = ResaultTorGeometric[ax, bx + 1, 0];
                            y4 = ResaultTorGeometric[ax, bx + 1, 1];
                            z4 = ResaultTorGeometric[ax, bx + 1, 2];

                        }
                        else
                        {

                            // если это последний меридиан, то в качестве следующего мы берем начальный (замыкаем геометрию фигуры)
                            x3 = ResaultTorGeometric[ax + 1, 0, 0];
                            y3 = ResaultTorGeometric[ax + 1, 0, 1];
                            z3 = ResaultTorGeometric[ax + 1, 0, 2];

                            x4 = ResaultTorGeometric[ax, 0, 0];
                            y4 = ResaultTorGeometric[ax, 0, 1];
                            z4 = ResaultTorGeometric[ax, 0, 2];

                        }

                    }
                    else // данный элемент ax последний, следовательно мы будем использовать начальный (нулевой) вместо данного ax
                    {

                        // следующей точкой будет нулевая ax
                        x2 = ResaultTorGeometric[0, bx, 0];
                        y2 = ResaultTorGeometric[0, bx, 1];
                        z2 = ResaultTorGeometric[0, bx, 2];


                        if (bx + 1 < Iter - 1)
                        {

                            x3 = ResaultTorGeometric[0, bx + 1, 0];
                            y3 = ResaultTorGeometric[0, bx + 1, 1];
                            z3 = ResaultTorGeometric[0, bx + 1, 2];

                            x4 = ResaultTorGeometric[ax, bx + 1, 0];
                            y4 = ResaultTorGeometric[ax, bx + 1, 1];
                            z4 = ResaultTorGeometric[ax, bx + 1, 2];

                        }
                        else
                        {

                            x3 = ResaultTorGeometric[0, 0, 0];
                            y3 = ResaultTorGeometric[0, 0, 1];
                            z3 = ResaultTorGeometric[0, 0, 2];

                            x4 = ResaultTorGeometric[ax, 0, 0];
                            y4 = ResaultTorGeometric[ax, 0, 1];
                            z4 = ResaultTorGeometric[ax, 0, 2];

                        }

                    }

                    // переменные для расчета нормали
                    double n1 = 0, n2 = 0, n3 = 0;

                    // нормаль будем расчитывать как векторное произведение граней полигона
                    // для нулевого элемента нормаль мы будем считать немного по-другому

                    // на самом деле разница в расчете нормали актуальна только для последнего и первого полигона на меридиане

                    if (ax == 0) // при расчете нормали для ax мы будем использовать точки 1,2,3
                    {

                        n1 = (y2 - y1) * (z3 - z1) - (y3 - y1) * (z2 - z1);
                        n2 = (z2 - z1) * (x3 - x1) - (z3 - z1) * (x2 - x1);
                        n3 = (x2 - x1) * (y3 - y1) - (x3 - x1) * (y2 - y1);

                    }
                    else // для остальных - 1,3,4
                    {

                        n1 = (y4 - y3) * (z1 - z3) - (y1 - y3) * (z4 - z3);
                        n2 = (z4 - z3) * (x1 - x3) - (z1 - z3) * (x4 - x3);
                        n3 = (x4 - x3) * (y1 - y3) - (x1 - x3) * (y4 - y3);

                    }


                    // если не включен режим GL_NORMILIZE, то мы должны в обязательном порядке
                    // произвести нормализацию вектора нормали, перед тем как передать информацию о нормали
                    double n5 = (double)Math.Sqrt(n1 * n1 + n2 * n2 + n3 * n3);
                    n1 /= (n5 + 0.01);
                    n2 /= (n5 + 0.01);
                    n3 /= (n5 + 0.01);

                    // передаем информацию о нормали
                    Gl.glNormal3d(-n1, -n2, -n3);

                    // передаем 4 вершины для отрисовки полигона
                    Gl.glVertex3d(x1, y1, z1);
                    Gl.glVertex3d(x2, y2, z2);
                    Gl.glVertex3d(x3, y3, z3);
                    Gl.glVertex3d(x4, y4, z4);

                }
            }

            // завершаем выбранный режим рисования полигонов
            Gl.glEnd();

            Gl.glScalef(10f, 10f, 10f);
        }

        private void CalculateRotationBody()
        {
            count_elements = 25;

            var elements_count = 0;

            double x, y, z;

            int y1 = 50, y2 = 65, y3 = 30;

            int x1 = 9, x2 = 12, x3 = 30;

            double w1, w2, w3;

            // вычисления всех значений y для x, пренадлежащего промежутку от a=2 до b=8, с шагом в 0.1f 
            for (x = -10; x < 40; x += 2)
            {
                // задаем полином Лагранжа для набора приближений x1, x2, x3 -> y1, y2, y3

                w1 = ((x - x2) * (x - x3)) / ((x1 - x2) * (x1 - x3));
                w2 = ((x - x1) * (x - x3)) / ((x2 - x1) * (x2 - x3));
                w3 = ((x - x1) * (x - x2)) / ((x3 - x1) * (x3 - x2));

                y = w1 * y1 + w2 * y2 + w3 * y3;

                z = elements_count;

                // запись координаты x 
                GeometricTorArray[elements_count, 0] = x;
                // запись координаты y 
                GeometricTorArray[elements_count, 1] = y;
                // запись координаты z
                GeometricTorArray[elements_count, 2] = z;

                // подсчет элементов 
                elements_count++;
            }

            // построение геометрии тела вращения
            // принцип сводится к двум циклам - на основе первого перебираются
            // вершины в геометрической последовательности
            // второй использует параметр Iter - производит поворот последней линии геометрии вокруг центра тела вращения
            // при этом используется заранее определенный угол angle, который определяется как 2*Pi / количество меридиан объекта
            // за счет выполнения этого алгоритма получается набор вершин, описывающих оболочку тела врещения
            // остается только соединить эти точки в режиме рисования примитивов для получения
            // визуализированного объекта

            // цикл по последовательности точек кривой, на основе которой будет построено тело вращения
            for (int ax = 0; ax < count_elements; ax++)
            {

                // цикл по меридианам объекта, заранее определенным в программе
                for (int bx = 0; bx < Iter; bx++)
                {

                    // для всех (bx > 0) элементов алгоритма используются предыдушая построенная последовательность
                    // для ее поворота на установленный угол
                    if (bx > 0)
                    {

                        double new_x = ResaultTorGeometric[ax, bx - 1, 0] * Math.Cos(Angle) - ResaultTorGeometric[ax, bx - 1, 1] * Math.Sin(Angle);
                        double new_y = ResaultTorGeometric[ax, bx - 1, 0] * Math.Sin(Angle) + ResaultTorGeometric[ax, bx - 1, 1] * Math.Cos(Angle);
                        ResaultTorGeometric[ax, bx, 0] = new_x;
                        ResaultTorGeometric[ax, bx, 1] = new_y;
                        ResaultTorGeometric[ax, bx, 2] = GeometricTorArray[ax, 2];

                    }
                    else // для построения первого меридиана мы используем начальную кривую, описывая ее нулевым значением угла поворота
                    {

                        double new_x = GeometricTorArray[ax, 0] * Math.Cos(0) - GeometricTorArray[ax, 1] * Math.Sin(0);
                        double new_y = GeometricTorArray[ax, 1] * Math.Sin(0) + GeometricTorArray[ax, 1] * Math.Cos(0);
                        ResaultTorGeometric[ax, bx, 0] = new_x;
                        ResaultTorGeometric[ax, bx, 1] = new_y;
                        ResaultTorGeometric[ax, bx, 2] = GeometricTorArray[ax, 2];

                    }
                }
            }
        }

        private void DrawOptionalRotationBody()
        {
            rotateAngle += 1;
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 77);
            Gl.glRotated(rotateAngle, 1, 0, 0);
            Gl.glRotated(rotateAngle, 0, 1, 0);
            Gl.glRotated(rotateAngle, 0, 0, 1);
            Gl.glScaled(0.2, 0.2, 1);
            DrawRotationBody();
            Gl.glPopMatrix();
        }

        private void DrawKid()
        {
            Gl.glPushMatrix();
            Gl.glTranslated(15, 89.8, 26.7);
            Gl.glScaled(0.05, 0.05, 1);
            DrawRotationBody();
            Gl.glPopMatrix();
            Model.DrawModel();
        }

        // вектор гравитации
        private float[] Grav = new float[3];
        // ускорение груза
        private float[] power = new float[3];
        // коэфицент увеличение силы
        private float amplification;

        bool _isBroken = false;

        double _angle, _radiusTralley, _height = 0;

        // набранная скорость
        private float[] speed = new float[3];

        public double GetTranslateHumanX
        {
            get { return _translateHumanX; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            soundOn = checkBox2.Checked;
        }

        private void Booom()
        {
            Random rnd = new Random();

            explosion.SetNewPosition(15, 0, 65);
            // случайную силу
            explosion.SetNewPower(rnd.Next(20, 80));
            // и активируем сам взрыв
            explosion.Boooom(_globalTime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProgrammDrawingEngine.Filter_1();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            boomIsOn = checkBox3.Checked;
        }

        public double GetTranslateHumanY
        {
            get { return _translateHumanY; }
        }

        public double GetTranslateHumanZ
        {
            get { return _translateHumanZ; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showHuman = checkBox1.Checked;
            button2.Visible = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            needToStopAnim = false;
            isAnimating = true;
            StartSliding(15, 89.8, 26.7, _globalTime);
            if (soundOn)
            {
                if (trackBar2.Value > trackBar2.Maximum / 2)
                    soundPlayer = new SoundPlayer(@"sliding2x.wav");
                else
                    soundPlayer = new SoundPlayer(@"scrime.wav");
                soundPlayer.Play();
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            var inentsiv = -1 + trackBar2.Value / 10f;

            _abmbientIntesive[0] = inentsiv;
            _abmbientIntesive[1] = inentsiv;
            _abmbientIntesive[2] = inentsiv;

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, _abmbientIntesive);

            if (trackBar2.Value > trackBar2.Maximum / 2)
            {
                isDay = true;
            }
            else
            {
                isDay = false;
            }
        }

        public double GetAngle
        {
            get { return _angle; }
        }

        public void StartSliding(double x, double y, double z, float startTime)
        {
            Random rnd = new Random();
            lastTime = startTime;

            speed[0] = 0;
            speed[1] = 0;
            speed[2] = 0;

            Grav[0] = 0;
            Grav[1] = 4f;
            Grav[2] = 0;

            _translateHumanX = 0;
            _translateHumanY = 0;
            _translateHumanZ = -1;

            amplification = 13.33f;

            float _power_rnd = rnd.Next(46 / 20, 46);

            power[0] = _power_rnd * ((float)rnd.Next(100, 1000) / 1000.0f) * 5;
            power[1] = _power_rnd * ((float)rnd.Next(100, 1000) / 1000.0f) * 5;
            power[2] = _power_rnd * ((float)rnd.Next(100, 1000) / 1000.0f) * 5;
        }

        public void DrawSlidingHuman(float timeNow)
        {
            /*_translateCargoX = 15 + (radiusTralley) * Math.Cos(angle * 2 * Math.PI / 360.0);
            _translateCargoY = 90 + (radiusTralley) * Math.Sin(angle * 2 * Math.PI / 360.0);*/

            UpdatePositionHuman(timeNow);

            Gl.glPushMatrix();
            Gl.glTranslated(15, 90, _translateHumanZ);
            Gl.glRotated(_angle, 0, 0, 1);
            Gl.glTranslated(-15, -90, -_translateHumanZ);

            Gl.glTranslated(_translateHumanX, _translateHumanY, _translateHumanZ);
            DrawKid();
            Gl.glPopMatrix();
        }

        private void UpdatePositionHuman(float timeNow)
        {
            float dTime = timeNow - lastTime;
            lastTime = timeNow;
            if (!needToStopAnim)
            {
                for (int a = 0; a < 1; a++)
                {
                    if (power[a] < 100)
                    {
                        power[a] += 0.0001f * dTime;
                    }

                    if (_translateHumanZ > -25)
                    {
                        _translateHumanY -= (speed[a] * dTime + (Grav[a] + power[a]) * dTime * dTime);
                        _translateHumanZ -= (speed[a] * dTime + (Grav[a] + power[a]) * dTime * dTime);
                    }
                    else
                    {
                        needToStopAnim = true;
                        isAnimating = false;
                        _translateHumanZ = -25;
                        if (boomIsOn)
                            Booom();
                    }

                    speed[a] += (Grav[a] + power[a]) * dTime;
                }

            }
        }

        private void DrawGirlyanda()
        {
            if (!isDay)
            {
                Random rnd = new Random();
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, arrayGirlyanda[rnd.Next(0, 3)]);

                Gl.glPushMatrix();
                Gl.glPushMatrix();
                Gl.glTranslated(13, 139, 60);
                Gl.glRotated(90, 1, 0, 0);
                Gl.glScaled(5, 7.5, 0);

                DrawPicture();

                Gl.glPopMatrix();
                Gl.glPopMatrix();


                // отключаем режим текстурирования
                Gl.glDisable(Gl.GL_TEXTURE_2D);
            }
        }
    }
}
