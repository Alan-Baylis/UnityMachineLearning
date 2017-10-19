# UnityMachineLearning

A small app to test Tensorflow and Unity interoperability. The app allows user to draw an image out of a few categories and to execute the neural network that evaluates the category of drawn image.

Tensorflow has been used to train a convolutional network and the serialized result can be found in Assets/quick_draw_classifier.bytes. In Unity project
![TensorFlowSharp](https://github.com/migueldeicaza/TensorFlowSharp) is then used to import and execute that that network.

![interface](https://user-images.githubusercontent.com/1475615/31780813-7da0be30-b4ff-11e7-91cd-9a06a42d34a9.png)
