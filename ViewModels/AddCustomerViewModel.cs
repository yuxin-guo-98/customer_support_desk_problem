using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using customersupport.Model;
using customersupport.Commands;
using System.Collections.ObjectModel;

namespace customersupport.ViewModels
{
    public class AddCustomerViewModel : INotifyPropertyChanged
    {
        #region Notify Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        CustomerSupport ObjCustomerSupport;
        //Constructor
        public AddCustomerViewModel()
        {
            ObjCustomerSupport = new CustomerSupport();
            LoadData();
            ACustomer = new CustomerDTO();
            saveCommand = new AddCustomerCommand(Save);
            updateCommand = new AddCustomerCommand(Update);
            deleteCommand = new AddCustomerCommand(Delete);
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region Display Operation
        private ObservableCollection<CustomerDTO> customerList;

        public ObservableCollection<CustomerDTO> CustomerList
        {
            get { return customerList; }
            set { customerList = value; OnPropertyChanged("CustomerList"); }
        }

        private void LoadData()
        {
            CustomerList = new ObservableCollection<CustomerDTO>(ObjCustomerSupport.GetAll()); 
        }
        #endregion



        #region SaveOperation
        private CustomerDTO aCustomer;
        public CustomerDTO ACustomer
        {
            get { return aCustomer; }
            set { aCustomer = value; OnPropertyChanged("ACustomer"); }
        }

        private AddCustomerCommand saveCommand;
       
        public AddCustomerCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjCustomerSupport.Add(ACustomer);
                LoadData();
                if (IsSaved)
                    Message = "Input saved.";
                else
                    Message = "Failed to save. Please try again.";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Search Operation
        //not implemented
        #endregion

        #region Update Operation
        private AddCustomerCommand updateCommand;
        public AddCustomerCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = ObjCustomerSupport.Update(ACustomer);
                if (IsUpdated)
                {
                    Message = "Change updated.";
                    LoadData();
                }
                else
                {
                    Message = "Update failed. Please try again.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DeleteOperation
        private AddCustomerCommand deleteCommand;
        public AddCustomerCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var IsDeleted = ObjCustomerSupport.Delete(ACustomer.Name);
                if (IsDeleted)
                {
                    Message = "Customer deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed. Please try again";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
    }
}
