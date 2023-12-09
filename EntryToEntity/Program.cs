using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO.Pipes;
using System.Text;
using Data;
using Model;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        using (DataContex dc = new DataContex())
        {
            Standing realMadrid = new Standing("Реал Мадрид", "Мадрид", 4, 0, 1);
            Standing girona = new Standing("Жірона", "Жірона", 4, 0, 1);
            Standing barcelona = new Standing("Барселона", "Барселона", 3, 1, 1);
            Standing atleticoMadrid = new Standing("Атлетіко Мадрид", "Мадрид", 3, 2, 0);
            Standing atleticoBilbao = new Standing("Атлетік Більбао", "Більбао", 3, 0, 2);
            dc.Standings.Add(realMadrid);
            dc.Standings.Add(girona);
            dc.Standings.Add(barcelona);
            dc.Standings.Add(atleticoMadrid);
            dc.Standings.Add(atleticoBilbao);
            dc.SaveChanges();
            var standings = dc.Standings.ToList();
            Console.WriteLine("Турнірна талиця: ");
            Console.WriteLine();
            Console.WriteLine("{0,-25} {1,-20} {2,-10} {3,-10} {4,-10}","Назва команди","Назва міста","W","L","D");
            Console.WriteLine();
            foreach (var standing in standings)
            {
                Console.WriteLine("{0,-25} {1,-20} {2,-10} {3,-10} {4,-10}", standing.name, standing.city, standing.wins, standing.defeats, standing.draws);
            }
        }



    }
}