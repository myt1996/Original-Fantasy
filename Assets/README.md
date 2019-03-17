WONDERDOT - RPG Overworld Tileset

================================================================================================

Contents ---------------------------------------------------------------------------------------

README.md							-This file
LICENSE.md							-License for Unity Technology script used for animated tiles+
ExampleScene.unity					-Example scene showcasing tileset

Tile Spritesheets/..
	Overworld_Tileset.png			-Tileset
	OceanNoTransparency_Tileset.png	-Ocean (upper) tiles merged with ocean (under) tiles
	OceanReduced_Tileset.png		-Ocean (under) tiles removing duplicate (rotated) tiles
	TropicalExtras_Tileset.png		-A small, tropical-themed extension to the overworld tileset

Tile Palettes/..
	OverworldPalette.prefab			-Example palette
	2x2OceanTilesPalette.prefab		-The 2x2 sized tiles are in a seperate palette
									 to keep the Tile Palette window looking nice

Tiles/..							-All tiles used in the Tile Palettes.

Extras/...
	Guide.html						-Documentation on use with examples and tips
	GuideImages/...					-Guide.html images

	Scenes.tmx						-A collection of example scenes (open in Tiled Map Editor)
	GuideExamples.tmx				-All maps used for examples in the documention
	OverworldTileset.tsx			-Tileset data for the .tmx files

Scripts/..
	2D-Extras/AnimatedTile.cs		-Used for animated tiles. Part of Unity Technology script
									 collection '2D-extras'. More information & full package:
									 https://github.com/Unity-Technologies/2d-extras
									 

v1.0 -------------------------------------------------------------------------------------------

-Grass fields, short grass fields, hills, paths
-Trees
-Cliffs (inc. beach & ocean transitions)
-Beaches
-Mountains
-Mountainside entrance
-Buildings
	Castle x2
	Village house x10
	Fort x2
	Tower x1
-Castle walls
-Rivers
-Waterfalls
-River->ocean transition
-Ocean shore, cliff ocean shore, beach shore
-Shore<->Cliff Shore<->Beach Shore transitions
-Ocean under layers (shallow, standard, deep) + transitions

v1.1 -------------------------------------------------------------------------------------------

-Unity example including:
	Tileset sliced and tiles named appropriately
	Tile palettes
	Animated tiles set up using 2D-extras
	Example scene
-Files renamed/reorganised be more consistent with Unity - sorry!
-New tiles added
	Bridge tiles
	Cave entrance tiles
	Cave/mine/dungeon entrance tiles for cliffs
-Added missing ocean sparkle tile
-Fixed some missing pixels in ocean-cliff-grass transition tiles

v1.2 ---------------------------------------------------------

-Tropical trees / jungle
-Huts
-Volcano
-Large rocks

================================================================================================

Thank you for your support!

-Pita

twitter.com/pita_akm
pita.madgwick@gmail.com