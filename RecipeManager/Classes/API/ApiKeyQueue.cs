// Author: Liron Katsif
// File Name: ApiKeyQueue.cs
// Project Name: RecipeManager
// Creation Date: Dec 13, 2024
// Modified Date: Jan 11, 2025
// Description: ApiKeyQueue class represents a queue for managing API keys.
//              Each key has a daily quota and when fully reached, by using stack structure we move to use the next api key
//              It includes attributes for the list of API keys and provides methods to enqueue, dequeue, and peek at the keys, as well as determine if a key should be dequeued based on the response.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public static class ApiKeyQueue
    {
        //class constant
        const int ZERO_INDEX = 0;
        const int MIN_POINTS_API = 6;

        //4 api keys available for usage. Each api key can be used until daily capcity is reached, then we move touse the next unused key. 
        const string API_KEY_7 = "df7b16ba5b8b46d2b94cc334726a5eff";
        const string API_KEY_6 = "780b88d37d02469e90baf6392265cb67";
        const string API_KEY_5 = "da996cb4bab849288a8cde7ef057552b";
        const string API_KEY_4 = "f42369d26e6947ed949468dd55d5bdde";
        const string API_KEY_3 = "87112b6b7c4f4ca18fa96c222463108d";
        const string API_KEY_2 = "2da1b1757c304eb68c92cfe839852aaf";
        const string API_KEY_1 = "ba7b8a41937c4c6987e2c79f11579861";

        //queue with available api keys
        static List<string> apiQueue = new List<string>
        {
            API_KEY_1, API_KEY_2, API_KEY_3, API_KEY_4, API_KEY_5, API_KEY_6, API_KEY_7
        };

        // Pre: None
        // Post: None
        // Description: Sends a test request to the Spoonacular API using the current API key and dequeues the key if it is fully used.
        public async static Task InitQueueKey()
        {
            //url to use for api call
            string url = $"https://api.spoonacular.com/food/ingredients/autocomplete?apiKey={Peek()}&query=appl&metaInformation=true";

            try
            {
                //using the built in http api client for call
                using (HttpClient client = new HttpClient())
                {
                    //make the call
                    HttpResponseMessage response = await client.GetAsync(url);

                    //check if should dequeue based on response, and if so, recursivly run this method again
                    if (DequeueIfFullyUsed(response))
                    {
                        await InitQueueKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // Pre: a string key - what should be put into the queue
        // Post: none
        // Description: adds a key to the back of a queue
        public static void Enqueue(string key)
        {
            apiQueue.Add(key);
        }

        // Pre: None
        // Post: Returns the front item of the queue.
        // Description: Returns and removes the item at the front of the queue, or null if none exists.
        public static string Dequeue()
        {
            //Maintain the front of the queue for return
            string result = null;

            //Only remove an Item if possible
            if (apiQueue.Count > 0)
            {
                //store the result and remove the first index
                result = apiQueue[ZERO_INDEX];
                apiQueue.RemoveAt(ZERO_INDEX);

                //Enqueue the worn out key back into the queue, for multi day long usage. if the user doesn't turn off the program for a day for instance.
                //  There shouldn't be an instance where there are no more apiKeys, as the regenerate their calls daily
                Enqueue(result);
            }

            //return the key removed from the front
            return result;
        }

        // Pre: None
        // Post: Returns the front item of the queue.
        // Description: Returns the item at the front of the queue, or null if none exists.
        public static string Peek()
        {
            //Maintain the front of the queue for return
            string result = null;

            //Only retrieve the Item if possible
            if (apiQueue.Count > 0)
            {
                result = apiQueue[0];
            }

            //return the front key of the queue
            return result; 
        }

        // Pre: response - The HTTP response message to check.
        // Post: Returns true if the API key should be dequeued based on the response, otherwise false.
        // Description: Checks if the API key is fully used based on the response and dequeues it if necessary.
        public static bool DequeueIfFullyUsed(HttpResponseMessage response)
        {
            //if the api call wasn't succesfull, or the number of api points left in the key today is less than 6, than dequqe the current key, and return false
            if (!response.IsSuccessStatusCode || (response.Headers.TryGetValues("X-API-Quota-Left", out var quotaHeaders) && Convert.ToDouble(quotaHeaders.FirstOrDefault()) < MIN_POINTS_API)) 
            {
                Dequeue();
                return true;
            }

            //the response was succesful
            return false;
        }
    }
}
