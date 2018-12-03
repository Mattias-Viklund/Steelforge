using SFML.Graphics;
namespace Steelforge.Engine.TileSystem
{
    public class Tile : Drawable
    {
        public Color color;

        public Tile()
        {
            color = Color.White;

        }

        public Tile(Color color)
        {
            this.color = color;

        }

        public void Draw(RenderTarget target, RenderStates states)
        {

            
        }

        public void SetColor(Color color)
        {
            

        }
    }
}
