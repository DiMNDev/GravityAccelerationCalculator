// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

(double lat, double gLat) CalculateAccelerationAtLatitude()
{
    Console.WriteLine("Enter a Latitude");
    try
    {
        double Latitude = Convert.ToDouble(Console.ReadLine()!);
        Console.WriteLine($"gLat({Latitude})= 978.0309 + 5.18552(sin({Latitude})^2) - 0.00570 (sin(2({Latitude}))^2)");

        double latRad = Latitude * Math.PI / 180;
        double a = 978.0309;
        double b = 5.18552;
        double c = 0.00570;

        double dLat = latRad * 2;
        double bLatSin = Math.Sin(latRad);
        double cLatSin = Math.Sin(dLat);

        double bLatSinPow = Math.Pow(bLatSin, 2);
        double cLatSinPow = Math.Pow(cLatSin, 2);

        double bLatSinPow2 = b * bLatSinPow;
        double cLatSinPow2 = c * cLatSinPow;

        double gLat = a + bLatSinPow2 - cLatSinPow2;
        return (Latitude, gLat);

    }
    catch
    {
        Console.WriteLine("Latitude Invalid");
        CalculateAccelerationAtLatitude();
    }
    return (0.0, 0.0);
}

(double lat, double gLat) CalculateAccelerationAtLatitudeAuto(double Latitude)
{
    double latRad = Latitude * Math.PI / 180;
    double a = 978.0309;
    double b = 5.18552;
    double c = 0.00570;

    double dLat = latRad * 2;
    double bLatSin = Math.Sin(latRad);
    double cLatSin = Math.Sin(dLat);

    double bLatSinPow = Math.Pow(bLatSin, 2);
    double cLatSinPow = Math.Pow(cLatSin, 2);

    double bLatSinPow2 = b * bLatSinPow;
    double cLatSinPow2 = c * cLatSinPow;

    double gLat = a + bLatSinPow2 - cLatSinPow2;
    return (Latitude, gLat);

}

(double lat, double gLat) value = CalculateAccelerationAtLatitude();

Console.WriteLine($"gLat({value.lat}) = {value.gLat}");

(double latMin, double gLatMin) FindMinimumAccelerationLatitude()
{
    double latMin = 0;
    double gLatMin = 0;
    for (double i = 00.01; i < 180.00; i += 0.01)
    {
        (double LatR, double gLatR) = CalculateAccelerationAtLatitudeAuto(i);
        if (gLatR < gLatMin)
        {
            latMin = LatR;
            gLatMin = gLatR;
        }
    }

    return (latMin, gLatMin);
}

(double latMax, double gLatMax) FindMaximumAccelerationLatitude()
{
    double latMax = 0;
    double gLatMax = 0;
    for (double i = 00.01; i < 180.00; i += 0.01)
    {
        (double LatR, double gLatR) = CalculateAccelerationAtLatitudeAuto(i);
        if (gLatR > gLatMax)
        {
            latMax = LatR;
            gLatMax = gLatR;
        }
    }
    return (latMax, gLatMax);

}

// (double latMin, double gLatMin) = FindMinimumAccelerationLatitude();


// (double latMax, double gLatMax) = FindMaximumAccelerationLatitude();
GravitationalAccelerationCalculator.FindMaxAtLattitude();
(double latMax, double gLatMax) = GravitationalAccelerationCalculator.Maximum;
Console.WriteLine($"Maximum Acceleration {gLatMax} @ {latMax}");

GravitationalAccelerationCalculator.FindMinAtLattitude();
(double latMin, double gLatMin) = GravitationalAccelerationCalculator.Minimum;
Console.WriteLine($"Minimum Acceleration {gLatMin} @ {latMin}");

public class GravitationalAccelerationCalculator
{
    public static (double lat, double gLat) Minimum { get; set; }
    public static (double lat, double gLat) Maximum { get; set; }
    public static void FindMaxAtLattitude()
    {
        for (double i = 00.00; i <= 90.0; i += 0.1)
        {
            (double LatR, double gLatR) = CalculateAccelerationAtLatitudeAuto(i);
            if (gLatR > Maximum.gLat)
            {
                Maximum = (LatR, gLatR);
            }
        }
    }
    public static void FindMinAtLattitude()
    {
        Minimum = (1000, 1000);
        for (double i = 00.00; i <= 90.00; i += 0.1)
        {
            (double LatR, double gLatR) = CalculateAccelerationAtLatitudeAuto(i);
            if (gLatR < Minimum.gLat)
            {
                Minimum = (LatR, gLatR);
            }
        }
    }

    public static (double lat, double gLat) CalculateAccelerationAtLatitudeAuto(double Latitude)
    {
        double latRad = Latitude * Math.PI / 180;
        double a = 978.0309;
        double b = 5.18552;
        double c = 0.00570;

        double dLat = latRad * 2;
        double bLatSin = Math.Sin(latRad);
        double cLatSin = Math.Sin(dLat);

        double bLatSinPow = Math.Pow(bLatSin, 2);
        double cLatSinPow = Math.Pow(cLatSin, 2);

        double bLatSinPow2 = b * bLatSinPow;
        double cLatSinPow2 = c * cLatSinPow;

        double gLat = a + bLatSinPow2 - cLatSinPow2;
        return (Latitude, gLat);

    }
}