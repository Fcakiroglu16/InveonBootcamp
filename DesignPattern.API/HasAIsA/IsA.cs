using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.HasAIsA
{
    public class Client
    {
        public Client()
        {
            // Duplicate
            // Runtime car behavior

            var vehicle = new CarA();

            vehicle.Forward();
            vehicle.Backward();
            vehicle.Left();
            vehicle.Right();

            var isIf = true;

            if (isIf)
            {
                vehicle.ChangeLeftOrRightBehavior(new NormalCarLeftOrRightBehavior());
                vehicle.Left();
                vehicle.Right();
            }
        }
    }

    public interface IBackwardBehavior
    {
        void Backward();
    }

    public interface ILeftOrRightBehavior
    {
        void Left();
        void Right();
    }

    public class SuperCarLeftOrRightBehavior : ILeftOrRightBehavior
    {
        public void Left()
        {
            Console.WriteLine("Super- Left");
        }

        public void Right()
        {
            Console.WriteLine("Super- Right");
        }
    }

    public class NormalCarLeftOrRightBehavior : ILeftOrRightBehavior
    {
        public void Left()
        {
            Console.WriteLine("Normal- Left");
        }

        public void Right()
        {
            Console.WriteLine("Normal- Right");
        }
    }

    public class SuperBackwardBehavior : IBackwardBehavior
    {
        public void Backward()
        {
            Console.WriteLine("Super Backward");
        }
    }

    public class NormalBackwardBehavior : IBackwardBehavior
    {
        public void Backward()
        {
            Console.WriteLine("Normal Backward");
        }
    }


    public abstract class Vehicle
    {
        protected IBackwardBehavior backwardBehavior;
        protected ILeftOrRightBehavior leftOrRightBehavior;

        public void ChangeLeftOrRightBehavior(ILeftOrRightBehavior leftOrRightBehavior)
        {
            this.leftOrRightBehavior = leftOrRightBehavior;
        }

        public void ChangeBackwardBehavior(IBackwardBehavior backwardBehavior)
        {
            this.backwardBehavior = backwardBehavior;
        }

        public void Forward()
        {
            Console.WriteLine("Forward");
        }

        public virtual void Backward()
        {
            this.backwardBehavior.Backward();
        }

        public abstract void Left();
        public abstract void Right();
    }

    public class CarA : Vehicle
    {
        public CarA()
        {
            backwardBehavior = new NormalBackwardBehavior();
            leftOrRightBehavior = new SuperCarLeftOrRightBehavior();
        }

        public override void Backward()
        {
            Console.WriteLine("A");
            base.Backward();
        }


        public override void Left()
        {
            leftOrRightBehavior.Left();
        }

        public override void Right()
        {
            leftOrRightBehavior.Right();
        }
    }

    public partial class CarB : Vehicle
    {
        public CarB()
        {
            backwardBehavior = new SuperBackwardBehavior();
            leftOrRightBehavior = new NormalCarLeftOrRightBehavior();
        }

        public override void Backward()
        {
            backwardBehavior.Backward();
        }

        public override void Left()
        {
            leftOrRightBehavior.Left();
        }

        public override void Right()
        {
            leftOrRightBehavior.Right();
        }
    }

    public class CarC : Vehicle
    {
        public override void Backward()
        {
            Console.WriteLine("A-Backward");
        }

        public override void Left()
        {
            Console.WriteLine("B-Left");
        }

        public override void Right()
        {
            Console.WriteLine("B-Right");
        }
    }
}