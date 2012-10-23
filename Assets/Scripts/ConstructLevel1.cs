using UnityEngine;
using System.Collections;

public class ConstructLevel1 : MonoBehaviour
{

	public GameObject brick;
	public GameObject steel;
	public GameObject tank;
	public GameObject eagle;

	private const int EMPTY_TYPE = 0;
	private const int PLAYR_TYPE = 1;
	private const int ENEMY_TYPE = 2;
	private const int BRICK_TYPE = 3;
	private const int STEEL_TYPE = 4;
	private const int EAGLE_TYPE = 5;

	private const int CELL_SIZE = 32;

	private int[,] map = 
		{{3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0}
		,{0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 3}
		,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
		,{0, 0, 2, 0, 4, 0, 0, 0, 3, 0, 0, 3, 4, 0, 0, 0}
		,{0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 3, 3, 3, 3, 0}
		,{0, 3, 3, 3, 0, 3, 3, 0, 3, 0, 0, 3, 0, 0, 0, 0}
		,{0, 0, 0, 3, 0, 3, 3, 0, 3, 3, 3, 3, 0, 0, 0, 0}
		,{0, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
		,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0}
		,{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
		,{0, 3, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0}
		,{0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 3, 0, 0}
		,{0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 3, 0, 0}
		,{3, 3, 3, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0}
		,{0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 0, 0, 3, 3, 3}
		,{0, 0, 0, 0, 0, 0, 0, 3, 5, 3, 0, 0, 0, 0, 0, 0}};

	void Start()
	{
		for (int i = 0; i < 16; i++)
		{
			for (int j = 0; j < 16; j++)
			{
				Engine engine = null;
				switch (map[i, j])
				{
					case ENEMY_TYPE:
						var enemy = Instantiate(tank, new Vector3(CELL_SIZE * j - 240, 15, 240 - CELL_SIZE * i), Quaternion.identity) as GameObject;
						enemy.AddComponent<Brain>();
						engine = enemy.GetComponent<Engine>();
						if (engine != null)
						{
							engine.team = 1;
						}
						break;
					case PLAYR_TYPE:
						var player = Instantiate(tank, new Vector3(CELL_SIZE * j - 240, 15, 240 - CELL_SIZE * i), Quaternion.identity) as GameObject;
						player.AddComponent<PlayerController>();
						engine = player.GetComponent<Engine>();
						if (engine != null)
						{
							engine.team = 0;
						}
						break;
					case BRICK_TYPE:
						Instantiate(brick, new Vector3(CELL_SIZE * j - 240, 15, 240 - CELL_SIZE * i), Quaternion.identity);
						break;
					case STEEL_TYPE:
						Instantiate(steel, new Vector3(CELL_SIZE * j - 240, 15, 240 - CELL_SIZE * i), Quaternion.identity);
						break;
					case EAGLE_TYPE:
						Instantiate(eagle, new Vector3(CELL_SIZE * j - 240, 15, 240 - CELL_SIZE * i), Quaternion.identity);
						break;
				}
				//Instantiate(brick, new Vector3(CELL_SIZE * j - 240, 5, -120 + 120 * i), Quaternion.identity);
				//Instantiate(brick, new Vector3(-120 + 120 * i, 5, CELL_SIZE * j - 240 ), Quaternion.identity);
			}
		}
		/*for (int i = 0; i < 15; i++) {
			Instantiate(brick, new Vector3(32 * i - 240, 5, -240), Quaternion.identity);
		}
		
		for (int i = 0; i < 15; i++) {
			Instantiate(brick, new Vector3(32 * i - 240, 5, 240), Quaternion.identity);
		}
		
		for (int i = 0; i < 15; i++) {
			Instantiate(brick, new Vector3(240, 5, 32 * i - 240), Quaternion.identity);
		}
		
		for (int i = 0; i < 15; i++) {
			Instantiate(brick, new Vector3(-240, 5, 32 * i - 240), Quaternion.identity);
		}*/

	}

	// Update is called once per frame
	void Update()
	{

	}
}
