using System;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security;

public class cardHolder
{
    //OOP variables
    string cardNum = string.Empty;
    string firstName = string.Empty;
    string lastName = string.Empty;
    double balance;
    int pin;


    //Initialize and Instantiate Constructors
    public cardHolder(string cardNum, string firstName, string lastName, double balance, int pin)
    {
        this.cardNum = cardNum;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
        this.pin = pin;
    }

    //Set getters
    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }


    //Set Setters
    public void setcardNum(string newcardNum)
    {
        cardNum = newcardNum;
    }

    public void setfirstName(string newfirstName)
    {
        firstName = newfirstName;
    }

    public void setlastName(string newlastName)
    {
        lastName = newlastName;
    }

    public void setbalance(double newbalance)
    {
        balance = newbalance;
    }

    public void setPin(int newpin)
    {
        pin = newpin;
    }

    //Functions 
    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("What will like to do today?");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Change Pin");
            Console.WriteLine("5. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much ££ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setbalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your ££. Your new balnce is: " + currentUser.getBalance());
        }

        void withdrawal(cardHolder currentUser)
        {
            Console.WriteLine("How much ££ will you like to withdraw");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Check balance against withdrawal amount
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setbalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Withdrawal Completed. Thank you for using us!");

            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        void setPin (cardHolder currentUser)
        {
            
            try
            {
                Console.WriteLine("Enter your new pin: ");

                int setNew = int.Parse(Console.ReadLine());

                currentUser.pin = setNew;

                Console.WriteLine("Your new pin is:" + currentUser.pin);

              

            }
            catch { Console.WriteLine("Enter integers only!"); }
            
            

        }

        //Create List of random card holders

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234567890", "John", "Smith", 150.31, 1234));
        cardHolders.Add(new cardHolder("0987654321", "Jason", "Carter", 170.71, 5678));
        cardHolders.Add(new cardHolder("1357908642", "Hazel", "Monet", 120.51, 0987));
        cardHolders.Add(new cardHolder("1234567890", "Roger", "Don", 250.35, 4321));
        cardHolders.Add(new cardHolder("1234567890", "Van Der Saar", "Eve", 350.31, 7531));

        //Prompt User
        Console.WriteLine("Welcome to the ATM");
        Console.WriteLine("Please enter your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against customer lists
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Try again."); }

            }
            catch
            {
                Console.WriteLine("Card not recognized. Try again.");
            }

        }

        Console.WriteLine("Enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again"); }

            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again.");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");

        int Option = 0;

        do
        {
            printOptions();

            try
            {
                Option = int.Parse(Console.ReadLine());

            }
            catch { }
            if (Option == 1 ) { deposit(currentUser); }
            else if (Option == 2) { withdrawal(currentUser); }
            else if (Option == 3) { balance(currentUser); }
            else if (Option == 4) { setPin(currentUser); }
            else if (Option == 5) { break; }
            else { Option = 0; }
        }
        while (Option != 5);
        Console.WriteLine("Thank you have a nice day!");
    }

}