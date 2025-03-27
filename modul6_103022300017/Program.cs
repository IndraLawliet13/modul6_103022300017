using System.Diagnostics.Contracts;
class SayaTubeVideo
{
    private int id, playCount;
    private string title;
    public SayaTubeVideo(string ttl)
    {
        Random rand = new Random();
        id = rand.Next(11111, 99999);
        try
        {
            checked
            {
                Contract.Requires(ttl.Length <= 200 );
                Contract.Requires(ttl != null);
                this.title = ttl;
            } 
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        try
        {
            checked
            {
                Contract.Requires(count <= 25000000);
                Contract.Requires(count > 0);
                this.playCount += count;
            }  
        }catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
    public int getPlayCount()
    {
        return this.playCount;
    }
    public string getTitle()
    {
        return this.title;
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string username;
    public SayaTubeUser(string username)
    {
        Random rand = new Random();
        id = rand.Next(11111, 99999);
        try
        {
            checked
            {
                Contract.Requires(username.Length <= 100);
                Contract.Requires(username != null);
                this.username = username;
            }
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        uploadedVideos = new List<SayaTubeVideo>();
    }
    public int GetTotalVideoPlayCount()
    {
        int count = 0;
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            count += uploadedVideos[i].getPlayCount();
        }
        return count;
    }
    public void AddVideo(SayaTubeVideo video)
    {
        try
        {
            checked
            {
                Contract.Requires(video != null);
                Contract.Requires(video.getPlayCount() < int.MaxValue);
                uploadedVideos.Add(video);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("Username: " + username);
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine("Video "+(i+1)+" judul: " + uploadedVideos[i].getTitle());
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        string username = "Indra Yuda Adi Saputra";
        SayaTubeUser user = new SayaTubeUser(username);
        List<string> judul = new List<string>();
        judul.Add("Iron Man 1");
        judul.Add("Iron Man 2");
        judul.Add("Iron Man 3");
        judul.Add("Spiderman 1");
        judul.Add("Spiderman 2");
        judul.Add("Spiderman 3");
        judul.Add("Avengers End Game");
        judul.Add("Hulk");
        judul.Add("Thor");
        judul.Add("Money Heist");
        for (int i = 0; i < judul.Count; i++)
        {
            user.AddVideo(new SayaTubeVideo("Review Film " + judul[i] + " oleh " + username));
        }
        user.PrintAllVideoPlaycount();
    }
}