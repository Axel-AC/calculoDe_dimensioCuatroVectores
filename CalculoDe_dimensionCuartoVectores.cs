using System;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace CalculoDe_dimensionCuartoVectores
{
    public class Vec4
    {
        //Propiedades del vector
        public float X, Y, Z, W;

        //Constructor | Esto es para inicializar los valores en los vectores
        public Vec4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        //Operador suma
        public static Vec4 operator +(Vec4 a, Vec4 b)
        {
            return new Vec4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
        }

        //Operador resta
        public static Vec4 operator -(Vec4 a, Vec4 b)
        {
            return new Vec4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
        }

        //Operador multiplicacion por escalar
        public static Vec4 operator *(Vec4 a, float slr)
        {
            return new Vec4(a.X * slr, a.Y * slr, a.Z * slr, a.W * slr);
        }

        //Metodo para clacular la magnitud del vector
        public float Magnitud()
        {
            //Utilizar el metodo Math.sqrt() | Para poder calcular con raiz cuadra implementada dentro de la biblioteca Math
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
        }

        //Metodo para normalizar el vector
        public Vec4 Norm()
        {
            float magnitud = Magnitud();
            return magnitud == 0 ? new Vec4(0, 0, 0, 0) : new Vec4(X / magnitud, Y / magnitud, Z / magnitud, W / magnitud);
        }

        //Metodo para calcular el producto escalar entre vetores
        public static float dotProduct(Vec4 a, Vec4 b, Vec4 c, Vec4 d)
        {
            return (a.X * b.X * c.X * d.X + a.Y * b.Y * c.Y * d.Y + a.Z * b.Z * c.Z * d.Z + a.W * b.W * c.W * d.W);
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z},{W}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Definir 4 vectores
            List<Vec4> vectores = new List<Vec4>
            {
                new Vec4(1,2,3,4),
                new Vec4(2,4,3,5),
                new Vec4(3,5,4,6),
                new Vec4(4,6,5,7)
            };


            Vec4 v1 = new Vec4(1, 2, 3, 4);
            Vec4 v2 = new Vec4(2, 4, 3, 5);
            Vec4 v3 = new Vec4(3, 5, 4, 6);
            Vec4 v4 = new Vec4(4, 6, 5, 7);

            //Operacion vectorial
            Vec4 r = v1 + v2 - v3 * 0.5f + v4;
            Console.WriteLine("Operaciones vectoriales");
            Console.WriteLine($"Operacion vectorial de los 4 vectores: {r}");

            // Magnitud de los vectores
            for (int i = 0; i < vectores.Count; i++)
            {
                Console.WriteLine("Magnitud de vectores");
                Console.WriteLine($"Vectores {i + 1}; {vectores[i]} | Magnitud: {vectores[i].Magnitud()}");
            }

            //Vectores normalizadosP
            for (int a = 0; a < vectores.Count; a++)
            {
                Console.WriteLine("Vectores normalizados");
                Console.WriteLine($"Vector {a + 1};{vectores[a]} | Magnitud: {vectores[a].Norm()}");
            }

            //Producto escalar
            for (int i = 0; i < vectores.Count - 1; i++)
            {
                Console.WriteLine("Producto escalar entre vectores:");
                float dotProduct = Vec4.dotProduct(vectores[i], vectores[i + 1], vectores[Math.Min(i + 2, vectores.Count - 1)], vectores[Math.Min(i + 3, vectores.Count - 1)]);
                Console.WriteLine($"Producto escalar entre vectores {i + 1}, {i + 2}, {i + 3} y {i + 4}: {dotProduct}");
            }


            Dec();
        }

        static public void Dec()
        {

            //Instrucciones al User
            Console.WriteLine("Operaciones vectoriales");
            Console.WriteLine("Si deseas hacer una operacion de vectores, precionar la tecla 'v'");
            Console.WriteLine("Si deseas finalizar el programa preciona la tecla 'x'");
            string d = Console.ReadLine();

            if (d == "v")
            {
                while (true)
                {
                    Console.WriteLine("Operaciones que podras realizar:");
                    Console.WriteLine("1.Suma de vectores");
                    Console.WriteLine("2.Resta de vectores");
                    Console.WriteLine("3.Multiplicacion por escalar");
                    Console.WriteLine("4.Calculo para la magnitud del vector");


                    Console.WriteLine("Que operacion deseas realizar?? | Ingresa el numero de acuerdo a la operacion que desees");
                    int D = int.Parse(Console.ReadLine());

                    switch (D)
                    {
                        case 1:
                            while (true)
                            {
                                Console.WriteLine("Ingresa 4 vectores para poder realizar la suma.");
                                string v0 = Console.ReadLine();

                                float[] valores0 = v0.Split(' ').Select(float.Parse).ToArray();
                                if (valores0.Length == 4)
                                {
                                    Vec4 nVec0 = new Vec4(valores0[0], valores0[1], valores0[2], valores0[3]);
                                    float rV0 = valores0[0] + valores0[1] + valores0[2] + valores0[3];
                                    Console.WriteLine($"La suma de los vectores es de {rV0}");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Error");
                                }
                            }
                            break;

                        case 2:
                            while (true)
                            {
                                Console.WriteLine("Ingresa 4 vectores para realizar la resta.");
                                string v1 = Console.ReadLine();

                                float[] valores1 = v1.Split(' ').Select(float.Parse).ToArray();
                                if (valores1.Length == 4)
                                {
                                    Vec4 nVec1 = new Vec4(valores1[0], valores1[1], valores1[2], valores1[3]);
                                    float rV1 = valores1[0] - valores1[1] - valores1[2] - valores1[3];
                                    Console.WriteLine($"La resta de los vectores es de {rV1}");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Error");
                                }
                            }
                            break;

                        case 3:
                            while (true)
                            {
                                Console.WriteLine("Ingresa 4 vectores para realizar la resta.");
                                string v2 = Console.ReadLine();

                                float[] valores2 = v2.Split(' ').Select(float.Parse).ToArray();
                                if (valores2.Length == 4)
                                {
                                    Vec4 nVec2 = new Vec4(valores2[0], valores2[1], valores2[2], valores2[3]);
                                    float rV2 = valores2[0] * 0.5f + valores2[1] * 0.5f + valores2[2] * 0.5f + valores2[3] * 0.5f;
                                    Console.WriteLine($"La multiplicacion por escalar de los vectores es de {rV2}");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Error");
                                }
                            }
                            break;

                        case 4:
                            while (true)
                            {
                                Console.WriteLine("Ingresa 4 vectores para realizar la resta.");
                                string v3 = Console.ReadLine();

                                float[] valores3 = v3.Split(' ').Select(float.Parse).ToArray();
                                if (valores3.Length == 4)
                                {
                                    Vec4 nVec3 = new Vec4(valores3[0], valores3[1], valores3[2], valores3[3]);
                                    float rV3 = valores3[0] * valores3[0] + valores3[1] * valores3[1] + valores3[2] * valores3[2] + valores3[3] * valores3[3];
                                    Console.WriteLine($"La resta de los vectores es de {rV3}");
                                    break;
                                }
                                else
                                {
                                    Console.Write("Error");
                                }
                            }
                            break;
                    }

                    Console.WriteLine("Si deseas hacer mas operaciones vuelve a ingresar un numero");
                    Console.WriteLine("Si deseas terminar con la ejecucuion del programa ingresa la tecla 'esc'");
                    var k = Console.ReadKey();

                    if (k.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Cerrando el programa...");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}