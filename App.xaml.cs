using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace custom_game_engine;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Loop();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }

    protected void Loop(){
        Stopwatch time;
        while(true){
            // Game loop
            time = Stopwatch.StartNew();

            InputStruct input = InputReader.ReadInput();
            Physics.Input(input);

            UI.Update();

            Physics.NextTick();
            Renderer.Render();


            //Wait until the frame has finished
            while(time.ElapsedMilliseconds < 1000/60);
        }
    }
}

