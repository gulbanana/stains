namespace Stains.State;

public class Blueprint
{
    public Pulse r;
    public string rname = "R";
    public Pulse g;
    public string gname = "G";
    public Pulse b;
    public string bname = "B";

    public void Update(TimeSpan elapsed)
    {        
        var delta = elapsed.TotalSeconds;

        r.Tick(delta);
        g.Tick(delta/2.0);
        b.Tick(delta/3.0);
    }
}