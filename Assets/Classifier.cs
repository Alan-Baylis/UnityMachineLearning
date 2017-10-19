using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TensorFlow;

public class Classifier : MonoBehaviour
{
    public Texture2D inputImage;
    public TextAsset graphModel;
    public Text outputText;

    private float[,] inputValues;
    private TFGraph graph;
    private TFSession session;

    private string[] categories = { "anvil", "apple", "axe", "banana", "bicycle", "butterfly", "candle", "carrot", "chair", "crown" };

    void Start()
	{
        Debug.Assert(inputImage.width == 28 && inputImage.height == 28, "Input image resolution must be 24");
        inputValues = new float[1, inputImage.width * inputImage.height];
        graph = new TFGraph();
        graph.Import(graphModel.bytes);
        session = new TFSession(graph);
    }

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Return))
        {
            outputText.text = "Classifying...";
            
            for (int y = 0; y < inputImage.height; ++y)
                for (int x = 0; x < inputImage.width; ++x)
                    inputValues[0, x + y * inputImage.width] = 1.0f - inputImage.GetPixel(x, (inputImage.height - 1) - y).r;
            
            var runner = session.GetRunner();
            runner.AddInput(graph["state"][0], inputValues);
            runner.AddInput(graph["dropout/keep_prob"][0], 1.0f);
            runner.Fetch(graph["action"][0]);

            float[,] output = runner.Run()[0].GetValue() as float[,];
            
            float maxOutput = float.MinValue;
            int maxOutputIndex = -1;
            for (int i = 0; i < output.Length; ++i)
            {
                if (output[0, i] > maxOutput)
                {
                    maxOutput = output[0, i];
                    maxOutputIndex = i;
                }
                Debug.Log(categories[i] + ": " + output[0, i]);
            }
            outputText.text = "Category:\n" + categories[maxOutputIndex];
        }
	}
}
