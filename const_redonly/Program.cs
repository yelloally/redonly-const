using System;

class MyLogger
{
    public void Info(string message)
    {
        Console.WriteLine($"{DateTime.Now}\t|INFO|\t{message}");
    }

    public void Error(string message)
    {
        Console.WriteLine($"{DateTime.Now}\t|ERROR|\t{message}");
    }

    public void Warn(string message)
    {
        Console.WriteLine($"{DateTime.Now}\t|WARN|\t{message}");
    }
}
class Car
{
    private const string ENGINE_IS_STARTED_MESSAGE = "The engine is running!";
    private const string ATTEMPT_TO_START_ENGINE_MESSAGE = "Starting the engine!";
    private const string ENGINE_HAS_ALREADY_STARTED_MESSAGE = "Ow, the engine is already starting!!!";
    private const string ATTEMPT_TO_DRIVE_MESSAGE = "Pedal to the metal!";
    private const string DRIVE_MESSAGE = "Let's go!";
    private const string DRIVE_ERROR_MESSAGE = "Ow, start the engine first!!!";

    private readonly MyLogger _myLogger;

    private bool isEngineStarted;

    public Car (MyLogger myLogger)
    {
        _myLogger = myLogger;
    }

    public void StartEngine()
    {
        _myLogger.Info(ATTEMPT_TO_START_ENGINE_MESSAGE);
        if (isEngineStarted)
        {
            _myLogger.Warn(ENGINE_HAS_ALREADY_STARTED_MESSAGE);
        }
        else
        {
            isEngineStarted = true;
            _myLogger.Info(ENGINE_IS_STARTED_MESSAGE);
        }
    }

    public void Drive()
    {
        _myLogger.Info(ATTEMPT_TO_DRIVE_MESSAGE);
        if (isEngineStarted)
            _myLogger.Info(DRIVE_MESSAGE);
        else
            _myLogger.Error(DRIVE_ERROR_MESSAGE);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(new MyLogger());
            car.Drive();
            car.StartEngine();
            car.StartEngine();
            car.Drive();
        }
    }

}