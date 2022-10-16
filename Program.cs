using System;

namespace Inheritance
{
    class Member
    {
        //field
        protected int annualFee;
        private string name;
        private int memberId;
        private int memberSince;

        //=======================================================

        //constructor
        public Member()
        {
            Console.WriteLine("Parent Constructor in Member Class with no parameter");
        }

        public Member(string pName, int pMemberId, int pMemberSince)
        {
            Console.WriteLine("Parent Constructor in Member Class with 3 Parameters");
            Console.WriteLine("\n***********************************");

            name = pName;
            memberId = pMemberId;
            memberSince = pMemberSince;
        }
        //=====================================================

        //Method for calculate fee
        //virtual means this method can ber overriden in derived class
        //virtual declared in parent/base class
        public virtual void CalculateAnnualFee()
        {
            annualFee = 0;
        } 
        public override string ToString()
        {
            return "\nName: " + name + "\nMember ID: " + memberId + "\nMember Since: "
                   + memberSince + "\nTotal Annual Fee: " + annualFee;

        }
    }

    class NormalMember : Member
    {
        //child constructor
        public NormalMember()
        {
            Console.WriteLine("Child Constructor in NormalMember Class with no parameter");
        }

        public NormalMember(string remarks, string name, int memberId,
            int memberSince) : base(name, memberId, memberSince)
        {
            Console.WriteLine("child constructor in NormalMember Class with 4 Parameters");
            Console.WriteLine("The added parameter is {0}", remarks);
            Console.WriteLine("\n***********************************");
        }
        //=============================================================

        //method normal member annual fee
        //override the method from base class
        public override void CalculateAnnualFee()
        {
            annualFee = 100 + 12 * 30;
        }
    }

    class VipMember : Member
    {
        //constructor
        public VipMember(string name, int memberId, int memberSince) : base(name, memberId, memberSince)
        {
            Console.WriteLine("Child Constructor in VipMember class with three parameters");
            Console.WriteLine("\n***********************************");
        }
        //===============================================

        //method vip annual feed
        public override void CalculateAnnualFee()
        {
            annualFee = 1200;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

            Member[] clubMembers = new Member[5];
            clubMembers[0] = new NormalMember("Special Rate", "James", 1, 2010);
            clubMembers[1] = new NormalMember("Normal Rate", "Andy", 2, 2011);
            clubMembers[2] = new NormalMember("Normal Rate", "Bill", 3, 2011);
            clubMembers[3] = new VipMember("Carol", 4, 2012);
            clubMembers[4] = new VipMember("Evelyn", 5, 2012);

            //use for each loop to calculate the annual fee
            //of each member and display the information

            foreach (Member m in clubMembers)
            {
                m.CalculateAnnualFee();
                Console.WriteLine(m.ToString());
            }

            //=====================note========================
            //In Polymorphism we declare virtual method in base class
            //then we override this method in derived class,
            //the method must have the same signature as virtual method
            //we declare an array of base class 
            //we use foreach loop to calculate the annual fee
            //of each member in derived class
            //and display the information
            //at run time the polymorphism is smart enough
            //to use method from the correct child class
            //even when that object is declared to be of base class

        } 
    }
}
