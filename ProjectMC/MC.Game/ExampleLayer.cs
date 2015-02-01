using System.Diagnostics;
using CocosSharp;

namespace MC
{
	class ExampleLayer : CCLayerColor
	{

		public ExampleLayer()
		{
			Color = new CCColor3B(100, 149, 237);
			Opacity = 255;
		}

		protected override void AddedToScene()
		{
			base.AddedToScene();
			Debug.WriteLine("HOGEEEEEEEEEEE");
			var label =
				new CCLabel("こんにちは", "ArialMT", 48)
				{
					Position = VisibleBoundsWorldspace.Center,
					Color = CCColor3B.White,
					HorizontalAlignment = CCTextAlignment.Center,
					VerticalAlignment = CCVerticalTextAlignment.Center,
					AnchorPoint = CCPoint.AnchorMiddle,
					IsAntialiased = true,
					BlendFunc = CCBlendFunc.AlphaBlend,
				};
			AddChild(label);
			var sprite =
				new CCSprite("GameThumbnail")
				{
					Position = VisibleBoundsWorldspace.Center + new CCPoint(0f, 64f),
					Color = CCColor3B.White,
					AnchorPoint = CCPoint.AnchorMiddle,
					IsAntialiased = true,
					BlendFunc = CCBlendFunc.AlphaBlend,
				};
			Debug.WriteLine(sprite.Texture.PixelsWide);
			AddChild(sprite);
			Schedule();
		}

		int x = 0;

		public override void Update(float dt)
		{
			if (x++ % 60 == 0)
			{
				Debug.WriteLine(dt * x);
			}
			base.Update(dt);
		}


	}
}
