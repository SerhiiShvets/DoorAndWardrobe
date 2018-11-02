using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Door Door1 = new Door();
            Wardrobe Wardrobe1 = new Wardrobe();

            Console.WriteLine("Choose the type of the door. Either R for round one or N for rectangular one.");
            string TypeOfTheDoor = "";
            do
            {
                TypeOfTheDoor = Console.ReadLine().ToUpper();
                switch (TypeOfTheDoor)
                {
                    case "R":
                        FillArrayOfRoundDoor(Door1);
                        break;
                    case "N":
                        FillArrayOfNormalDoor(Door1);
                        break;
                    default:
                        Console.WriteLine("Please input R or N.");
                        break;
                }
            } while (TypeOfTheDoor != "R" && TypeOfTheDoor != "N");

            Console.WriteLine("Choose the type of the wardrobe. Either C for cylindrical one or P for parallelepiped one.");
            string TypeOfTheWardrobe = "";
            do
            {
                TypeOfTheWardrobe = Console.ReadLine().ToUpper();
                switch (TypeOfTheWardrobe)
                {
                    case "C":
                        FillArrayOfCylindricWardrobe(Wardrobe1);
                        break;
                    case "P":
                        FillArrayOfNormalWardrobe(Wardrobe1);
                        break;
                    default:
                        Console.WriteLine("Please input C or P.");
                        break;

                }
            } while (TypeOfTheWardrobe != "C" && TypeOfTheWardrobe != "P");

            if (TypeOfTheDoor == "R" && TypeOfTheWardrobe == "C")
            {
                CompareRoundDimensions(Door1, Wardrobe1);
            }
            else if (TypeOfTheDoor == "N" && TypeOfTheWardrobe == "P")
            {
                CompareNormalDoorAndWardrobe(Door1.Dimensions, Wardrobe1.Dimensions);
            }
            else if (TypeOfTheDoor == "N" && TypeOfTheWardrobe == "C")
            {
                CompareNormalDoorAndRoundWardrobe(Door1, Wardrobe1);
            }
            else
            {
                Wardrobe1.Diagonals = Wardrobe1.GetDiagonals(Wardrobe1.Height, Wardrobe1.Width, Wardrobe1.Length);
                CompareRoundDoorAndNormalWardrobe(Door1, Wardrobe1);

            }

            Console.ReadKey();

        }

        static void FillArrayOfNormalDoor(Door door)
        {
            Console.WriteLine("Please, input the dimensions of the door.");

            bool IsDoubleOrNot;

            do
            {
                Console.WriteLine("Height:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out door.Height);
                if (IsDoubleOrNot && door.Height > 0)
                {
                    door.Dimensions[0] = door.Height;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || door.Height <= 0);

            do
            {
                Console.WriteLine("Width:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out door.Width);
                if (IsDoubleOrNot && door.Width > 0)
                {
                    door.Dimensions[1] = door.Width;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || door.Width <= 0);

        }

        static void FillArrayOfNormalWardrobe(Wardrobe wardrobe)
        {
            Console.WriteLine("Please, input the dimensions of the wardrobe.");
            bool IsDoubleOrNot;

            do
            {
                Console.WriteLine("Height:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out wardrobe.Height);
                if (IsDoubleOrNot && wardrobe.Height > 0)
                {
                    wardrobe.Dimensions[0] = wardrobe.Height;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || wardrobe.Height <= 0);

            do
            {
                Console.WriteLine("Width:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out wardrobe.Width);
                if (IsDoubleOrNot && wardrobe.Width > 0)
                {
                    wardrobe.Dimensions[1] = wardrobe.Width;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || wardrobe.Width <= 0);

            do
            {
                Console.WriteLine("Length:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out wardrobe.Length);
                if (IsDoubleOrNot && wardrobe.Length > 0)
                {
                    wardrobe.Dimensions[2] = double.Parse(Convert.ToString(wardrobe.Length));
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || wardrobe.Length <= 0);
        }

        static void FillArrayOfRoundDoor(Door door)
        {
            Console.WriteLine("Please, input the dimensions of the door.");

            bool IsDoubleOrNot;
            do
            {
                Console.WriteLine("Radius:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out door.Radius);
                if (IsDoubleOrNot && door.Radius > 0)
                {
                    door.Dimensions[0] = door.Radius;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || door.Radius <=0);

        }

        static void FillArrayOfCylindricWardrobe(Wardrobe wardrobe)
        {
            Console.WriteLine("Please, input the dimensions of the wardrobe.");

            bool IsDoubleOrNot;
            do
            {
                Console.WriteLine("Height:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out wardrobe.Height);
                if (IsDoubleOrNot && wardrobe.Height > 0)
                {
                    wardrobe.Dimensions[0] = wardrobe.Height;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || wardrobe.Height <= 0);

            do
            {
                Console.WriteLine("Radius:");
                IsDoubleOrNot = double.TryParse(Console.ReadLine(), out wardrobe.Radius);
                if (IsDoubleOrNot && wardrobe.Radius >0)
                {
                    wardrobe.Dimensions[1] = wardrobe.Radius;
                }
                else
                {
                    Console.WriteLine("Input should be a valid number");
                }
            } while (!IsDoubleOrNot || wardrobe.Radius <= 0);
        }


        static void CompareNormalDoorAndRoundWardrobe(Door door, Wardrobe wardrobe)
        {
            if (door.Height > wardrobe.Height && door.Width > wardrobe.Radius * 2)
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
            }
            else if (door.Width > wardrobe.Height && door.Height > wardrobe.Radius * 2)
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
            }
            else if (door.Height > wardrobe.Radius * 2 && door.Width > wardrobe.Radius * 2)
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
            }
            else
            {
                Console.WriteLine("The wardrobe will not get through the door");
            }
        }

        static void CompareRoundDoorAndNormalWardrobe(Door door, Wardrobe wardrobe)
        {

            if (door.Radius*2 > wardrobe.Diagonals[0] || door.Radius*2 > wardrobe.Diagonals[1] || door.Radius*2 > wardrobe.Diagonals[2])
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
            }
            else
            {
                Console.WriteLine("The wardrobe will not get through the door");
            }
        }

        static void CompareRoundDimensions(Door door, Wardrobe wardrobe)
        {
            if (door.Radius > wardrobe.Radius)
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
            }
            else
            {
                Console.WriteLine("The wardrobe will not get through the door");
            }
        }

        static void CompareNormalDoorAndWardrobe(double[] door,  double[] wardrobe)
        {
            bool passed = false;
            if (wardrobe[0] < door[0] && wardrobe[1] < door[1])
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
                passed = true;
            }
            else if (wardrobe[1] < door[0] && wardrobe[2] < door[1])
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
                passed = true;
            }
            else if (wardrobe[0] < door[0] && wardrobe[2] < door[1])
            {
                Console.WriteLine("The wardrobe is small enough to get through the door");
                passed = true;
            }
            else if (!passed)
            {
                Array.Reverse(door);

                if (wardrobe[0] < door[0] && wardrobe[1] < door[1])
                {
                    Console.WriteLine("The wardrobe is small enough to get through the door");
                }
                else if (wardrobe[1] < door[0] && wardrobe[2] < door[1])
                {
                    Console.WriteLine("The wardrobe is small enough to get through the door");
                }
                else if (wardrobe[0] < door[0] && wardrobe[2] < door[1])
                {
                    Console.WriteLine("The wardrobe is small enough to get through the door");
                }
                else
                {
                    Console.WriteLine("The wardrobe will not get through the door");
                }
            }
        }
    }
}
