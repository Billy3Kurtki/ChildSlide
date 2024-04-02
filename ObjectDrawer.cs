using System;
using Tao.FreeGlut;
using Tao.OpenGl;
using static System.Windows.Forms.AxHost;

namespace Kazakov_Kirill_PRI_120_lab_10
{
    internal class ObjectDrawer
    {
        public static void DrawEarth()
        {

            //Отрисовка земли
            Gl.glPushMatrix();
            Gl.glColor3f(0.12f, 0.97f, 0.13f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(-125, 125, -4);
            Gl.glVertex3d(125, 125, -4);
            Gl.glVertex3d(125, -125, -4);
            Gl.glVertex3d(-125, -125, -4);
            Gl.glEnd();
            Gl.glPopMatrix();

            // асфальт
            Gl.glPushMatrix();
            Gl.glColor3f(0.2f, 0.168f, 0.168f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(30, 105, -3.5);
            Gl.glVertex3d(112, 105, -3.5);
            Gl.glVertex3d(112, -105, -3.5);
            Gl.glVertex3d(30, -105, -3.5);
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        public static void DrawSlide()
        {
            // ГОРКА
            // Поручни 
            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 99, 10);
            Gl.glRotated(10, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 2);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 99, 10);
            Gl.glRotated(10, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 2);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 100, 0.6);
            Gl.glRotated(-67, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 0.2);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 100, 0.6);
            Gl.glRotated(-67, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 0.2);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 96, 18.7);
            Gl.glRotated(-67, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 0.2);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 96, 18.7);
            Gl.glRotated(-67, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 0.2);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            // сидушка
            Gl.glPushMatrix();
            Gl.glColor3f(0.27f, 0.24f, 0.26f);
            Gl.glTranslated(15, 92, 18.7);
            Gl.glScaled(0.6, 0.7, 0.05);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.79f, 0.15f, 0.15f);
            Gl.glTranslated(11.5, 91.7, 18.7);
            Gl.glScaled(0.1, 0.6, 0.1);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.79f, 0.15f, 0.15f);
            Gl.glTranslated(18.5, 91.7, 18.7);
            Gl.glScaled(0.1, 0.6, 0.1);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            // спуск
            Gl.glPushMatrix();
            Gl.glColor3f(0.27f, 0.24f, 0.26f);
            Gl.glTranslated(15, 75.6, 5.6);
            Gl.glRotated(45, 1, 0, 0);
            Gl.glScaled(0.6, 3.7, 0.05);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.79f, 0.15f, 0.15f);
            Gl.glTranslated(11.5, 75.6, 5.55);
            Gl.glRotated(45, 1, 0, 0);
            Gl.glScaled(0.1, 3.77, 0.1);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.79f, 0.15f, 0.15f);
            Gl.glTranslated(18.5, 75.6, 5.55);
            Gl.glRotated(45, 1, 0, 0);
            Gl.glScaled(0.1, 3.77, 0.1);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            // подпорки горки
            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 90, 6.9);
            Gl.glScaled(0.1, 0.1, 2.4);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 90, 6.9);
            Gl.glScaled(0.1, 0.1, 2.4);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 84, 3.9);
            Gl.glScaled(0.1, 0.1, 1.9);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 84, 3.9);
            Gl.glScaled(0.1, 0.1, 1.9);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 74, -1);
            Gl.glScaled(0.1, 0.1, 0.9);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 74, -1);
            Gl.glScaled(0.1, 0.1, 0.9);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            // Подпорки 
            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 97, 0);
            Gl.glScaled(0.1, 0.1, 1);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 97, 0);
            Gl.glScaled(0.1, 0.1, 1);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            // Лестница 
            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(12, 97, 10);
            Gl.glRotated(10, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 3);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            Gl.glTranslated(18, 97, 10);
            Gl.glRotated(10, 1, 0, 0);
            Gl.glScaled(0.1, 0.1, 3);
            Glut.glutSolidCube(10);
            Gl.glPopMatrix();
        }

        public static void DrawBorder()
        {
            int startX = -120; int startY = 122;
            int step = 6;
            int count = 40;
            int angle = 90;
            for (double j = 0; j < 4 * 90 - 1; j+=angle)
            {
                Gl.glPushMatrix();
                Gl.glRotated(j, 0, 0, 1);
                for (int i = startX; i < step * count + startX - 1; i += step)
                {
                    Gl.glPushMatrix();
                    Gl.glColor3f(0.35f, 0.27f, 0.125f);
                    Gl.glTranslated(i, startY, 2);
                    Gl.glScaled(0.2, 0.1, 1.4);
                    Glut.glutSolidCube(10);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glColor3f(0.35f, 0.27f, 0.125f);
                    Gl.glTranslated(i + step, startY, 2);
                    Gl.glScaled(0.2, 0.1, 1.4);
                    Glut.glutSolidCube(10);
                    Gl.glPopMatrix();

                    // поперечены
                    Gl.glPushMatrix();
                    Gl.glColor3f(0.35f, 0.27f, 0.125f);
                    Gl.glTranslated(i + step / 2, startY, 4);
                    Gl.glScaled(1, 0.1, 0.2);
                    Glut.glutSolidCube(10);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glColor3f(0.35f, 0.27f, 0.125f);
                    Gl.glTranslated(i + step / 2, startY, -1);
                    Gl.glScaled(1, 0.1, 0.2);
                    Glut.glutSolidCube(10);
                    Gl.glPopMatrix();
                }
                Gl.glPopMatrix();
            }
        }

        public static void DrawSandbox()
        {
            int startX = -40; int startY = 80;
            int centerX = -40; int centerY = 59; int centerZ = 0;
            
            int angle = 90;
            // sand
            Gl.glPushMatrix();
            Gl.glColor3f(0.77f, 0.81f, 0.48f);
            Gl.glTranslated(centerX, centerY, 0);
            Gl.glScaled(2, 2, 0.5);
            Glut.glutSolidSphere(10, 30, 30);
            Gl.glPopMatrix();

            for (double i = 0; i < 4 * 90 - 1; i += angle)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(centerX, centerY, centerZ);
                Gl.glRotated(i, 0, 0, 1);
                Gl.glTranslated(-centerX, -centerY, -centerZ);

                Gl.glPushMatrix();
                Gl.glColor3f(0.89f, 0.18f, 0.18f);
                Gl.glTranslated(startX, startY, 0.5);
                Gl.glScaled(4.2, 0.1, 0.9);
                Glut.glutSolidCube(10);
                Gl.glPopMatrix();

                Gl.glPushMatrix();
                Gl.glColor3f(0.79f, 0.91f, 0.04f);
                Gl.glTranslated(startX, startY - 1.5,5);
                Gl.glScaled(4.5, 0.6, 0.1);
                Glut.glutSolidCube(10);
                Gl.glPopMatrix();

                Gl.glPopMatrix();
            }
        }

        public static void DrawSnake()
        {
            Gl.glPushMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(50, 85, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(100, 85, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(100, 65, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(50, 65, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(100, 40, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(50, 40, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(100, 15, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(50, 15, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(80, 15, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(70, 40, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.17f, 0.17f, 0.94f);
            Gl.glTranslated(80, 65, -4);
            Gl.glScaled(0.5, 0.5, 2);
            Glut.glutSolidCylinder(3, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.54f, 0.54f, 0.55f);
            Gl.glTranslated(50, 85, 10);
            Gl.glRotated(90, 0, 1, 0);
            Gl.glScaled(0.5, 0.5, 5);
            Glut.glutSolidCylinder(2, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.54f, 0.54f, 0.55f);
            Gl.glTranslated(50, 65, 10);
            Gl.glRotated(90, 0, 1, 0);
            Gl.glScaled(0.5, 0.5, 3);
            Glut.glutSolidCylinder(2, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.54f, 0.54f, 0.55f);
            Gl.glTranslated(70, 40, 10);
            Gl.glRotated(90, 0, 1, 0);
            Gl.glScaled(0.5, 0.5, 3);
            Glut.glutSolidCylinder(2, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.54f, 0.54f, 0.55f);
            Gl.glTranslated(50, 15, 10);
            Gl.glRotated(90, 0, 1, 0);
            Gl.glScaled(0.5, 0.5, 3);
            Glut.glutSolidCylinder(2, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.54f, 0.54f, 0.55f);
            Gl.glTranslated(50, 65, 10);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glScaled(0.5, 0.5, 5);
            Glut.glutSolidCylinder(2, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glColor3f(0.54f, 0.54f, 0.55f);
            Gl.glTranslated(100, 85, 10);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glScaled(0.5, 0.5, 7);
            Glut.glutSolidCylinder(2, 10, 33, 33);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }
    }
}
