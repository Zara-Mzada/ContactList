using System;
using System.Collections;

namespace Contact
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] ContactList = new string[4][];

            ContactList[0] = new string[] {"1", "Zahra", "Malikzada", "0558944407" };
            ContactList[1] = new string[] {"2", "Mirvari", "Muradova", "0553223333" };
            ContactList[2] = new string[] {"3", "Sabir", "Aliyev", "0772453434" };
            ContactList[3] = new string[] {"4", "Namiq", "Salamov", "0556543434" };

            int contactID = 4;
            ReEnter:
            Console.Write("What do you want?:\n" +
                              "1. Show contacts\n" +
                              "2. Add contact\n" +
                              "3. Update contact\n" +
                              "4. Remove contact\n" +
                              "Enter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                ShowAllContacts();
            }
            else if (choice == "2")
            {
                AddContact();
                ShowAllContacts();
                goto ReEnter;
            }
            else if (choice == "3")
            {
                UpdateContact();
                goto ReEnter;
            }
            else if (choice == "4")
            {
                RemoveContact();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is not this choice! Enter again");
                goto ReEnter;
            }
            
            // Show contacts
            void ShowAllContacts()
            {
                for (int i = 0; i < ContactList.Length; i++)
                {
                    Console.WriteLine("============================\n" +
                                      $"Contact {ContactList[i][0]}:\n" +
                                      $"Name: {ContactList[i][1]}\n" +
                                      $"Surname: {ContactList[i][2]}\n" +
                                      $"Phone: {ContactList[i][3]}\n" +
                                      "=============================");
                }   
            }
            
            // Add contact
            void AddContact()
            {
                Array.Resize(ref ContactList, ContactList.Length + 1);
                Console.Write("Enter details:\n" +
                                  "Name: ");
                string name = Console.ReadLine();

                Console.Write("Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Phone: ");
                string phone = Console.ReadLine();

                int ID = contactID++;
                string id = ID.ToString();
                
                string[] addedContact = new[] {id, name, surname, phone };
                ContactList[ContactList.Length - 1] = addedContact;
            }
            
            // Update contact
            void UpdateContact()
            {
                ShowAllContacts();
                ReID:
                Console.Write("Which user do you want to update? Give user id: ");
                string choosenID = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < ContactList.Length; i++)
                {
                    if (ContactList[i][0] == choosenID)
                    {
                        ReProp:
                        Console.Write("Which property do you want to update:\n" +
                                          "1. Name\n" +
                                          "2. Surname\n" +
                                          "3. Phone\n" +
                                          "Enter: ");
                        string userSelection = Console.ReadLine();
                        if (userSelection == "1")
                        {
                            Console.Write("Enter name: ");
                            string name = Console.ReadLine();
                            for (int j = 0; j < ContactList[i].Length; j++)
                            {
                                ContactList[i][1] = name;
                            }
                            ShowAllContacts();
                        }
                        else if (userSelection == "2")
                        {
                            Console.Write("Enter surname: ");
                            string surname = Console.ReadLine();
                            for (int j = 0; j < ContactList[i].Length; j++)
                            {
                                ContactList[i][2] = surname;
                            }
                            ShowAllContacts();
                        }
                        else if (userSelection == "3")
                        {
                            Console.Write("Enter phone: ");
                            string phone = Console.ReadLine();
                            for (int j = 0; j < ContactList[i].Length; j++)
                            {
                                ContactList[i][3] = phone;
                            }
                            ShowAllContacts();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("There is not this property! Enter again");
                            goto ReProp;
                        }
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong id! Enter again");
                    goto ReID;
                }
                
            }
            
            // Remove contact
            void RemoveContact()
            {
                Console.Clear();
                ReRemove:
                ShowAllContacts();
                Console.Write("Which contact do you want to remove? Give id: ");
                string id = Console.ReadLine();

                bool found = false;
                for (int i = 0; i < ContactList.Length; i++)
                {
                    if (ContactList[i][0] == id)
                    {
                        for (int j = 0; j < ContactList[i].Length; j++)
                        {
                            ContactList[i][j] = null;
                        }
                    }
                }

                if (!found)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong id! Enter again");
                    goto ReRemove;
                }
                ShowAllContacts();
            }
        }

        
    }
}