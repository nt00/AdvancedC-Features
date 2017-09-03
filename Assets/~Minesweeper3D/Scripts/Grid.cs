using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper3D
{
    public class Grid : MonoBehaviour
    {
        public GameObject blockPrefab;
        // The grid's dimensions
        public int width = 10;
        public int height = 10;
        public int depth = 10;
        public float spacing = 1.2f; // How much spacing between each Block
        public bool isMine;

        // Multi-Dimesional Array storing the blocks (in this case 3D)
        private Block[,,] blocks;

        void Start()
        {
            // Generate blocks on startup
            GenerateBlocks();
        }

        //Spawns a block at position and returns the block component
        Block SpawnBlock(Vector3 pos)
        {
            GameObject clone = Instantiate(blockPrefab); // Instantiate clone
            clone.transform.position = pos; // Set Position 
            Block currentBlock = clone.GetComponent<Block>(); // Get Block component
            return currentBlock; // Return it
        }

        //Spawns blocks in a grid-like fashion
        void GenerateBlocks()
        {
            // Create 3D array to store all te blocks
            blocks = new Block[width, height, depth];

            // Loop through the X, Y, and Z axis of the 3D array 
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for(int z = 0; z < depth; z++)
                    {
                        // Calculate half size using array dimesions
                        Vector3 halfSize = new Vector3(width / 2, height / 2, depth / 2);
                        //Make sure to offset by half (so that elements are centered)
                        //// NOTE: Try without this line to see the difference visually when spawning
                        halfSize -= new Vector3(0.5f, 0.5f, 0.5f);
                        // Create position for element to pivot around Grid zero
                        Vector3 pos = new Vector3(x - halfSize.x, y - halfSize.y, z - halfSize.z);
                        // Apply spacing
                        pos *= spacing;
                        //Spawn the block at that position
                        Block block = SpawnBlock(pos);
                        // Attach block to grid as child
                        block.transform.SetParent(transform);
                        // Store array coordinate inside the block itself
                        block.x = x;
                        block.y = y;
                        block.z = z;
                        //Store block in the array at coordinates
                        blocks[x, y, z] = block;
                    }
                }
            }
        }

        // Count adjacent mines at element
        public int GetAdjacentMineCountAt(Block b)
        {
            int count = 0;
            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= -1; z++)
                    {
                        // Calculate adjacent element's index
                        int desiredX = b.x + x;

                        int desiredY = b.y + y;

                        int desiredZ = b.z + z;

                        // IF desiredX is within range of blocks array
                        if(desiredX <= blocks.Length)
                        {
                            //If the element at index is a mine
                            if(b == isMine)
                            {
                                // Increment count by 1
                                count++;
                            }
                        }

                        // IF desiredY is within range of blocks array
                        if (desiredY <= blocks.Length)
                        {
                            //If the element at index is a mine
                            if (b == isMine)
                            {
                                // Increment count by 1
                                count++;
                            }
                        }
                        // IF desiredZ is within range of blocks array
                        if (desiredZ <= blocks.Length)
                        {
                            //If the element at index is a mine
                            if (b == isMine)
                            {
                                // Increment count by 1
                                count++;
                            }
                        }
                    }
                }
            }

            return count;
        }
    }
}
