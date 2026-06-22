namespace Assignment1;

public struct RGB
{
    // I used byte because Red, Green, Blue values ranges between 0 and 255 as a byte
    public byte RedValue;
    public byte GreenValue;
    public byte BlueValue;

    public RGB(byte redValue, byte greenValue, byte blueValue)
    {
        RedValue = redValue;
        GreenValue = greenValue;
        BlueValue = blueValue;
    }

    public void ConvertToRed()
    {
        RedValue = 255;
        GreenValue = 0;
        BlueValue = 0;
    }
    
    public void ConvertToGreen()
    {
        RedValue = 0;
        GreenValue = 255;
        BlueValue = 0;
    }
    
    public void ConvertToBlue()
    {
        RedValue = 0;
        GreenValue = 0;
        BlueValue = 255;
    }
}