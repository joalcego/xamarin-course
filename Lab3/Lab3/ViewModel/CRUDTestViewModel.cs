using System;
using System.Collections.Generic;
using Lab3.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab3.ViewModel
{
    public class CRUDTestViewModel : BaseViewModel
    {
        #region Properties
        public enum SourceTypeEnum {
            JSON,
            XML,
            REST
        }

        private static CRUDTestViewModel Instance { get; set; }

        private ObservableCollection<CDModel> cdList;
        public ObservableCollection<CDModel> CDList {
            get {
                return cdList;
            }
            set {
                cdList = value;
                OnPropertyChanged("CDList");
            }
        }

        private SourceTypeEnum sourceType { get; set; }
        public SourceTypeEnum SourceType {
            get {
                return sourceType;
            }
            set {
                sourceType = value;
                OnPropertyChanged("SourceType");
            }
        }

        public ICommand ChangeSourceCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }

        #endregion

        #region Constructor
        private CRUDTestViewModel() {
            
        }

        public static CRUDTestViewModel GetInstance() {
            if(Instance == null) {
                Instance = new CRUDTestViewModel();
                Task.Run(() => Instance.InitClass().Wait());
            }
            return Instance;
        }

        private async Task InitClass() {
            await LoadPeople(SourceTypeEnum.XML);
        }

        private void InitCommand() {
            ChangeSourceCommand = new Command<string>(async (x) => await ChangeSource(x));
        }
        #endregion

        #region Methods
        private async Task LoadPeople(SourceTypeEnum source) {
            switch(source) {
                case SourceTypeEnum.JSON:
                    CDList = JSONModel.FindPeople();
                    break;
                case SourceTypeEnum.REST:
                    CDList = RESTModel.FindPeople();
                    break;
                case SourceTypeEnum.XML:
                    CDList = await XMLModel.FindPeople();
                    break;
            }
        }

        private async Task ChangeSource(string source) {
            switch(source) {
                case "JSON":
                    await LoadPeople(SourceTypeEnum.JSON);
                    break;
                case "REST":
                    await LoadPeople(SourceTypeEnum.REST);
                    break;
                case "XML":
                    await LoadPeople(SourceTypeEnum.XML);
                    break;
            }
        }
        #endregion
    }
}
