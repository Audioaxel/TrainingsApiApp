using ConsoleApp.Helper;

using WebApiLib;


internal class Program
{
    private static void Main(string[] args)
    {
        UiHelper.WriteLine(EColors.Green, "Welcome to Axel´s UselessApp!!!");
        UiHelper.WriteLine(EColors.Green, "If you are going to launch the api in a docker container type in: docker");

        string apiUrl = Console.ReadLine() == "docker" ? $"http://*:{GetDockerPort()}"
            : $"http://localhost:{GetLocalHostPort()}";

        var x = "test--urls";

        string[] argsApi = new string[] { $"--urls={apiUrl}", $"--spast={x}" };

        
        Task apiTask = Task.Run(() => Startup.BuildWebApi(argsApi));

        

             

        
        string input = null;
        int count = 0;
        
        while (input != "exit")
        {
            System.Console.WriteLine("Type in: exit");
            input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                count = 0;
            
            else if (++count == 20)
            {
                UiHelper.WriteLine(EColors.Red, "This program relies on console readline commands.");
                UiHelper.WriteLine(EColors.Red, "Run the docker image with the -it parameter");
                UiHelper.WriteLine(EColors.Red, "Bye...");
                break;
            }
        }




        string GetLocalHostPort()
        {
            UiHelper.WriteLine(EColors.Green, "Please Type in a Port:");
            return Console.ReadLine();
        }

        string GetDockerPort()
        {
            string portDocker = GetEnvironmentVariable();
            
            if (portDocker is null)
            {
                UiHelper.WriteLine(EColors.Green, "Cant find any Port. Pls type in a valid port.");
                portDocker = Console.ReadLine();
            }

            return portDocker;
        }

        string GetEnvironmentVariable()
        {
            string portDocker = Environment.GetEnvironmentVariable("PORT");
            if (portDocker is not null)
            {
                UiHelper.WriteLine(EColors.Yellow, $"Found Environment Variable: PORT={portDocker}");
                return portDocker;
            }
            return null;
        }
    }
}