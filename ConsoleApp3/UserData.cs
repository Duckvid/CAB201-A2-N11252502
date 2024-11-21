
using ClientInfo;
using System.Text.Json;
public class UserData
{
    public static ClientData Data = new ClientData();
    //public List<Client> Clients = new List<Client>();
    public static Client CurrentLogin { get; private set; }


    public static void Login(string email)
    {
        foreach (var client in Data.Clients)
        {
            if (client.Email == email)
            {
                CurrentLogin = client;
                return;
            }
        }
    }

    public static void SearchProducts(string searchPhrase)
    {
        var products = new List<Products.Item>();

        foreach (var client in Data.Clients)
        {
            if (client.Email != CurrentLogin.Email)
                if (client.products!= null)
                {
                foreach (var product in client.products)
                {
                    if (searchPhrase == "ALL")
                    {
                        products.Add(product);
                        continue;
                    }
                    else if (product.Name.Contains(searchPhrase))
                    {
                        products.Add(product);
                        continue;
                    }

                }
            }
        }
        Console.WriteLine("List of products");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} \t {p.Description} \t {p.price}");
        }
    }

    public static void Logout()
    {
        UserData.CurrentLogin = null;
    }

    public static void AddClient(Client client)
    {
        if (Data.Clients.Contains(client))
        {
            return;
        }

        Data.Clients.Add(client);
    }
    public static bool DoesClientEmailExist(string email)
    {
        foreach (var client in Data.Clients)
        {
            if (client.Email == email)
            {
                return true;
            }
        }
        return false;
    }

    public static bool DoesClientPasswordMatch(string email, string password)
    {
        foreach (var client in Data.Clients)
        {
            if (client.Email == email)
            {
                if (client.Password == password)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public static void SaveAll()
    {
        string fn = "data.json";
        using FileStream fs = File.Create(fn);
        var options = new JsonSerializerOptions();
        options.WriteIndented = true;
        JsonSerializer.Serialize(fs, Data, options);
        fs.Dispose();
    }
    public static void LoadAll()
    {
        if (File.Exists("data.json"))
        {
            var json = File.ReadAllText("data.json");

            Data = JsonSerializer.Deserialize<ClientData>(json) ?? new ClientData();
        }
    }
}

public class ClientData
{
    public List<Client> Clients { get; set; } = new List<Client>();
}