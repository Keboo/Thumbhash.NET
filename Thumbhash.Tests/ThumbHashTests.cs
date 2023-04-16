using System.Drawing;

using SkiaSharp;

namespace Thumbhash.Tests;

public class ThumbHashTests
{
    [Theory]
    [InlineData("firefox.png", "X5qGNQw7oElslqhGWfSE+Q6oJ1h2iHB2Rw==")]
    [InlineData("sunrise.jpg", "1QcSHQRnh493V4dIh4eXh1h4kJUI")]
    [InlineData("flower.jpg", "k0oGLQaSVsN0BVhn2oq2Z5SQUQcZ")]
    public void RgbaToThumbHash_WithImage_ReturnsHash(string fileName, string expectedHash)
    {
        //Arrange
        using SKBitmap bitmap = SKBitmap.Decode($"Images/{fileName}");
        using SKBitmap rgb = bitmap.Copy(SKColorType.Rgba8888);

        //Act
        byte[] hash = ThumbHash.RgbaToThumbHash(rgb.Width, rgb.Height, rgb.Bytes);
        
        //Assert
        string base64Hash = Convert.ToBase64String(hash);
        Assert.Equal(expectedHash, base64Hash);
    }
}