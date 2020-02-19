using RPS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPS.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private RSPResult _player;
        private RSPResult _computer;

        private Random _rand;

        public MainViewModel()
        {
            Player = RSPResult.None;
            Computer = RSPResult.None;
            _rand = new Random();
            Play = new ParametrizedRelayCommand(
                (param) =>
                {
                    if (param is /*RSPResult*/ string)
                    {
                        switch (param)
                        {
                            case /*RSPResult.Rock*/ "1": Player = RSPResult.Rock; break;
                            case /*RSPResult.Scissors*/ "2": Player = RSPResult.Scissors; break;
                            case /*RSPResult.Paper*/ "3": Player = RSPResult.Paper; break;
                            default: Player = RSPResult.None; break;
                        }
                        Computer = (RSPResult)_rand.Next(3) + 1;
                    }
                    
                },
                (param) => true
            );
        }

        public RSPResult Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                NotifyPropertyChanged();
            }
        }

        public RSPResult Computer
        {
            get
            {
                return _computer;
            }
            set
            {
                _computer = value;
                NotifyPropertyChanged();
            }
        }

        public ParametrizedRelayCommand Play { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
