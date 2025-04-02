using SimpleInjector;
using SimpleInjector.Lifestyles;
using UOW.Data;
using UOW.Models;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
       
        var container = new Container();

  
        container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        container.Register<ApplicationDbContext>(Lifestyle.Scoped);


        container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

     
        container.Verify();

    
        using (var scope = AsyncScopedLifestyle.BeginScope(container))
        {
            var unitOfWork = container.GetInstance<IUnitOfWork>();

            // 🔹 Ajouter une personne
            await unitOfWork.Persons.AddAsync(new Person { Name = "John Doe" });
            await unitOfWork.SaveChangesAsync();

            // 🔹 Récupérer toutes les personnes
            var persons = await unitOfWork.Persons.GetAllAsync();
            foreach (var person in persons)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
            }
        }
    }
}
