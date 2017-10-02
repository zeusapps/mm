using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Mm.Client.Infrastructure;
using Mm.Client.Services;
using Mm.Core.DTOs;

namespace Mm.Client.ViewModels
{
    public class MainViewModel : ViewModelBase, IInitializable
    {
        private readonly IDataService _dataService;
        private ObjPropertiesViewModel _current;

        public ICommand UpdateCommand => new RelayCommand(Update, () => Current != null);
        public ICommand DeleteCommand => new RelayCommand(Delete, () => Current != null);
        public ICommand CreateCommand => new RelayCommand(Create);
        public ICommand SaveCommand => new RelayCommand(Save, () => Current != null && !Properties.Contains(Current));

        public ObservableCollection<ObjPropertiesViewModel> Properties { get; } 
            = new ObservableCollection<ObjPropertiesViewModel>();

        public ObjPropertiesViewModel Current
        {
            get => _current;
            set => Set(ref _current, value);
        }

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task Initialize()
        {
            var data = await _dataService.GetAll();
            if (data != null)
            {
                foreach (var dto in data)
                {
                    Properties.Add(new ObjPropertiesViewModel(dto));
                }  
                RaisePropertyChanged(() => Properties);
            }
        }

        private void Create()
        {
            Current = new ObjPropertiesViewModel(new ObjPropertiesDto());
        }

        private async void Save()
        {
            var temp = Current;

            var result = await _dataService.Create(temp.Value);

            if (result == null)
            {
                return;
            }

            var vm = new ObjPropertiesViewModel(result);
            Properties.Add(vm);
            Current = vm;
        }

        private async void Update()
        {
            await _dataService.Update(Current.PropertyId.ToString(), Current.Value);
        }

        private async void Delete()
        {
            var temp = Current;
            var id = temp.PropertyId.ToString();
            var res = await _dataService.Delete(id);

            if (res)
            {
                Properties.Remove(temp);
            }
        }
    }
}
