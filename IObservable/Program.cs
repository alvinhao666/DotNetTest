using System;

namespace IObservable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define a provider and two observers.
            LocationTracker provider = new LocationTracker(); //被观察，跟踪对象

            LocationReporter reporter1 = new LocationReporter("FixedGPS"); //观察者
            reporter1.Subscribe(provider);

            LocationReporter reporter2 = new LocationReporter("MobileGPS"); //观察者
            reporter2.Subscribe(provider);

            provider.TrackLocation(new Location(47.6456, -122.1312));
            reporter1.Unsubscribe();
            Console.WriteLine("reporter1.Unsubscribe");

            provider.TrackLocation(new Location(47.6677, -122.1199));
            provider.TrackLocation(null);
            provider.EndTransmission();

            Console.ReadKey();
        }
    }
}
