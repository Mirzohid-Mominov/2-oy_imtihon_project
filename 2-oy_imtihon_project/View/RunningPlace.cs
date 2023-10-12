using _2_oy_imtihon_project.DataLayer.Models;
using _2_oy_imtihon_project.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _2_oy_imtihon_project.View
{
    public class RunningPlace
    {
        public RunningPlace()
        {
            SignIn();

        }

        public static FileContext<User> filecontext = new FileContext<User>(@"D:\Projects\2-oy_imtihon_project\2-oy_imtihon_project\FileServer\File\usersAndCategories.txt");
        List<User> AllusersList = filecontext.Readtext().ToList();

        static async Task SignIn()
        {
            Console.WriteLine("Welcome to our GymFlex Console app!");
            while (true)
            {
                Console.WriteLine("If you sign in yourself. 1 is the userCredential");
                Console.WriteLine("2 : Registering to website");
                Console.WriteLine("3 : TarifService to GymFlex club");
                Console.WriteLine("4 : Exit");
                

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await Usercredential();
                        break;
                        
                    case "2":
                        await Registering();
                        break;
                    case "3":
                        await TarifService();
                        break;
                    case "4":
                        Console.WriteLine("Thanks to use our website!");
                        return;
                    default:
                        Console.WriteLine("You chose the default choise");
                        break;
                }
            }
        }

        static async Task Usercredential()
        {
            Console.WriteLine("Welcome to first registering");

            Console.Write("Enter your firstName : ");
            var firstName = Console.ReadLine();
            
            Console.Write("Enter your lastName : ");
            var lastName = Console.ReadLine();
            
            Console.Write("Enter your PhoneNumber : ");
            var phoneNumber = Console.ReadLine();

            var user = new UserCredential()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };

            var createdUser = new UserCredentialService();
            createdUser.Create(user);
        }
        static async Task Registering()
        {

            while (true)
            {
                Console.WriteLine("Please select an option : ");
                Console.WriteLine("1 : AddUserToFile ");
                Console.WriteLine("2 : DeleteFromFileAnUser ");
                Console.WriteLine("3 : GetAllUser ");
                Console.WriteLine("4 : Search ");
                Console.WriteLine("5 : Update ");
                Console.WriteLine("6 : Exit ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await AddUsersToFile();
                        break;
                    case "2":
                        await DeleteFromFile();
                        break;
                    case "3":
                        await GetAllUser(); 
                        break;
                    case "4":
                        await Search();
                        break;
                    case "5":
                        await Update();
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using registration service!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        static async Task<bool> TarifService()
        {
            Console.WriteLine("Welcome to select Tarif");
            Console.WriteLine("We have 3 tarifs");
            Console.WriteLine("you can select 0 is the dayly tarif:)");
            Console.WriteLine("you can select 1 is the monthly tarif:)");
            Console.WriteLine("you can select 2 is the yearly tarif:)");

            var day = (int)Category.IsDay;
            var month = (int)Category.IsMonth;
            var year = (int)Category.IsYear;

            var userSchyot = new UserSchyot(1, "8600 3729 8482 8495", "Aloqa Bank", 5400000);
            var fitnesCharacters = new FitnessCharacters(27349482, "GymFlex");

            var tarifId = int.Parse(Console.ReadLine());
            
            if(tarifId == day)
            {
                Console.Write("You selected dayly tarif");

                Console.Write("Enter your Id. To transfer your money to GymFlex club : ");
                var id = int.Parse(Console.ReadLine());

                if(id == userSchyot.Id)
                {
                    Console.Write("Enter transfer Amount : ");
                    var moneyAmount = double.Parse(Console.ReadLine());
                    
                    var paymentService = new PaymentService();
                    paymentService.Transfer(userSchyot, fitnesCharacters, moneyAmount);
                    Console.WriteLine("Succesfully transfered to GymFkex schyot");
                }
            }
            else if(tarifId == month)
            {
                Console.Write("You selected monthly tarif");

                Console.Write("Enter your Id. To transfer your money to GymFlex club : ");
                var id = int.Parse(Console.ReadLine());

                if(id == userSchyot.Id)
                {
                    Console.Write("Enter transfer Amount : ");
                    var moneyAmount = double.Parse(Console.ReadLine());
                    
                    var paymentService = new PaymentService();
                    paymentService.Transfer(userSchyot, fitnesCharacters, moneyAmount);
                    Console.WriteLine("Succesfully transfered to GymFkex schyot");

                }
            }
            else if(tarifId == year)
            {
                Console.Write("You selected yearly tarif");

                Console.Write("Enter your Id. To transfer your money to GymFlex club : ");
                var id = int.Parse(Console.ReadLine());

                if(id == userSchyot.Id)
                {
                    Console.Write("Enter transfer Amount : ");
                    var moneyAmount = double.Parse(Console.ReadLine());
                    
                    var paymentService = new PaymentService();
                    paymentService.Transfer(userSchyot, fitnesCharacters, moneyAmount);
                    Console.WriteLine("Succesfully transfered to GymFkex schyot");

                }
            }
            return true;
        }

        static async Task AddUsersToFile()
        {


            Console.Write("Enter your FirstName : ");
            var firstName = Console.ReadLine();

            Console.Write("Enter your LastName : ");
            var lastName = Console.ReadLine();

            Console.Write("Enter Your Birthday : ");
            DateTime birthday;

            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Invalid datetime. Please enter a valid birthday!");
            }

            Console.Write("Enter your Weight : ");
            double weight;
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Invalid input. Please enter a valid input");
            }

            Console.Write("Enter your Height : ");
            double height;
            while (!double.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Invalid input. Please enter a valid input");
            }

            Console.Write("Enter your emailAddress : ");
            var emailAddress = Console.ReadLine();

            Console.Write("Enter your Password : ");
            var password = Console.ReadLine();

            Console.Write("Enter your UserName : ");
            var userName = Console.ReadLine();


            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBearth = birthday,
                Weight = weight,
                Height = height,
                EmailAddress = emailAddress,
                Password = password,
                UserName = userName
            };

            var userService = new UserService();
            userService.AddUserToFile(user);
        }

        static async Task DeleteFromFile()
        {
            Console.Write("Enter your id for delete : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid input");
            }

            var user = new User()
            {
                Id = id
            };

            var userService = new UserService();
            userService.DeleteFromFile(user.Id);
        }

        static async Task GetAllUser()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid input");
            }

            var user = new User()
            {
                Id = id
            };
            var userService = new UserService();
            userService.GetAllUser();
        }

        static async Task Search()
        {
            var id = int.Parse( Console.ReadLine());

            var user = new User()
            {
                Id = id
            };
            var userService = new UserService();
            userService.Search(user);
        }

        static async Task Update()
        {
            Console.Write("Enter your FirstName : ");
            var firstName = Console.ReadLine();

            Console.Write("Enter your LastName : ");
            var lastName = Console.ReadLine();

            Console.Write("Enter Your Birthday : ");
            DateTime birthday;

            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Invalid datetime. Please enter a valid birthday!");
            }

            Console.Write("Enter your Weight : ");
            double weight;
            while (!double.TryParse(Console.ReadLine(), out weight))
            {
                Console.WriteLine("Invalid input. Please enter a valid input");
            }

            Console.Write("Enter your Height : ");
            double height;
            while (!double.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Invalid input. Please enter a valid input");
            }

            Console.Write("Enter your emailAddress : ");
            var emailAddress = Console.ReadLine();

            Console.Write("Enter your Password : ");
            var password = Console.ReadLine();

            Console.Write("Enter your UserName : ");
            var userName = Console.ReadLine();


            var user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBearth = birthday,
                Weight = weight,
                Height = height,
                EmailAddress = emailAddress,
                Password = password,
                UserName = userName
            };

            var userService = new UserService();
            userService.Update(user);
        }
    }
}