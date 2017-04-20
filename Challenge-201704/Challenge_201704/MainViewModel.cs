using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Challenge_201704
{
    public enum LoadStatus { None, LoadingNow, Halted, Error, Completed };
    class MainViewModel : ViewModelBase
    {
        #region Commands
        private ICommand doTappedUser = null;
        public ICommand DoTappedUser
        {
            get
            {
                if (this.doTappedUser == null)
                {
                    this.doTappedUser = new RelayCommand<ItemTappedEventArgs>(async (args) =>
                    {
                        var user = args.Item as UserModel;
                        if (user != null)
                        {
                            var detailPage = new DetailPage() { BindingContext = user };
                            await App.Current.MainPage.Navigation.PushModalAsync(detailPage);
                        }
                        
                    });
                }
                return this.doTappedUser;
            }
        }
        #endregion

        #region Fields
        private LoadStatus loadingStatus = LoadStatus.None;
        public LoadStatus LoadingStatus
        {
            get { return this.loadingStatus; }
            set
            {
                if (this.loadingStatus != value)
                {
                    this.loadingStatus = value;
                    this.RaisePropertyChanged("LoadingStatus");
                }
            }
        }
        private ObservableCollection<UserModel> users = null;
        public ObservableCollection<UserModel> Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new ObservableCollection<UserModel>();
                    this.LoadUsers();
                }
                return this.users;
            }
            set
            {
                if (this.users != value)
                {
                    this.users = value;
                    this.RaisePropertyChanged("Users");
                }
            }
        }
        #endregion

        #region Function
        public Task LoadUsers(int limit = 10)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (this.LoadingStatus != LoadStatus.LoadingNow)
                    {
                        this.LoadingStatus = LoadStatus.LoadingNow;
                        for (int i = 0; i < limit; i++)
                        {
                            string json = "";
                            using (var httpClient = new HttpClient())
                            using (HttpResponseMessage resp = await httpClient.GetAsync("https://randomuser.me/api/"))
                            using (HttpContent contents = resp.Content)
                            {
                                json = await contents.ReadAsStringAsync();
                            }

                            var jMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                            var users = ((JArray)jMap["results"]).ToObject<IEnumerable<UserDTO>>();
                            foreach (var user in users)
                            {
                                this.Users.Add(new UserModel()
                                {
                                    Name = $"{user.Name["first"]} {user.Name["last"]}",
                                    Photo = user.Picture["large"],
                                    Thumbnail = user.Picture["thumbnail"],
                                    Email = user.Email,
                                    Gender = user.Gender,
                                    Phone = user.Phone,
                                    State = user.Location["state"]
                                });
                            }
                        }
                        this.LoadingStatus = LoadStatus.Completed;
                    }
                }
                catch (Exception e)
                {
                    this.LoadingStatus = LoadStatus.Error;
                }

            });
        }
        #endregion
    }
}
