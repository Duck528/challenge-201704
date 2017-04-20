using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge_201704
{
    public class UserModel : ObservableObject
    {
        private string name = "";
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        private string photo = "";
        public string Photo
        {
            get { return this.photo; }
            set
            {
                if (this.photo != value)
                {
                    this.photo = value;
                    this.RaisePropertyChanged("Photo");
                }
            }
        }

        private string thumbnail = "";
        public string Thumbnail
        {
            get { return this.thumbnail; }
            set
            {

                if (this.thumbnail != value)
                {
                    this.thumbnail = value;
                    this.RaisePropertyChanged("Thumbnail");
                }
            }
        }

        private string email = "";
        public string Email
        {
            get { return this.email; }
            set
            {
                if (this.email != value)
                {
                    this.email = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }

        private string gender = "";
        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (this.gender != value)
                {
                    this.gender = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }

        private string phone = "";
        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (this.phone != value)
                {
                    this.phone = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }

        private string state = "";
        public string State
        {
            get { return this.state; }
            set
            {
                if (this.state != value)
                {
                    this.state = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
    }
}
