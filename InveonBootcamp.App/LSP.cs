namespace InveonBootcamp.App.LSP
{
    public interface ITakePhoto
    {
        void TakePhoto();
    }


    public abstract class Phone
    {
        public void Call()
        {
            Console.WriteLine("Phone Call");
        }

        //public abstract void TakePhoto();
    }

    public class Iphone : Phone, ITakePhoto
    {
        //diamond problem.
        public void FaceTime()
        {
            Console.WriteLine("Iphone FaceTime");
        }


        public void TakePhoto()
        {
            Console.WriteLine("IPhone Take Photo");
        }
    }

    public class Nokia : Phone
    {
    }
}