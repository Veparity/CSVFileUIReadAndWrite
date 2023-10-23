





using CSVFileUI;
using DataAccessLibrary.Models;

Setting.InitializeConfiguration();
Setting.GetFile();

PersonalModel user1 = new PersonalModel();
user1.FirstName = "Test";
user1.LastName = "Tester";
user1.PhoneNumbers.Add("8675409333");

PersonalModel user2 = new PersonalModel();
user2.FirstName = "Tester";
user2.LastName = "Testerd";
user2.PhoneNumbers.Add("5555555555");

//Setting.CreateContact(user1);
//Setting.CreateContact(user2);

//Setting.UpdateContactFirstName("Jacqueline");
//Setting.RemovePhoneNumberFromUser("8675409333");

//Setting.RemoveUser();


Setting.GetAllContacts();



Console.ReadLine();