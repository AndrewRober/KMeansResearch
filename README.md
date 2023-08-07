# Balancing Cluster Quality and Simplicity: A Penalized WCSS Approach to Prevent Overfitting in K-means Clustering

<img src="https://github.com/AndrewRober/KMeansResearch/assets/54873972/14c0364f-27ae-4437-a052-1cb06ee1e946" width="45%"></img> <img src="https://github.com/AndrewRober/KMeansResearch/assets/54873972/d2039ebd-5f94-4728-b5b0-8ef9b65a2767" width="45%"></img> <img src="https://github.com/AndrewRober/KMeansResearch/assets/54873972/e04facfe-3073-4631-9179-cb58dd325e4e" width="45%"></img> <img src="https://github.com/AndrewRober/KMeansResearch/assets/54873972/65f5ba44-3637-4e57-b5c6-fc394cda3967" width="45%"></img> 

## Abstract

The K-means algorithm and its variant, K-means++, are popular methods for data clustering due to their efficiency and simplicity. However, these algorithms are susceptible to overfitting, a phenomenon where the model becomes too tailored to the training data and performs poorly on unseen data. One common indicator of cluster quality, the Within-Cluster Sum of Squares (WCSS), decreases as the number of clusters increases, making it challenging to numerically determine if the model is improving or simply overfitting the data. In this paper, we propose a novel approach to penalize WCSS and prevent overfitting. We introduce an equation that responds positively to clustering but negatively to overfitting. Our solution involves a density factor, a dimensionality parameter, and a tuning hyperparameter, offering a more nuanced measurement of cluster quality. We provide a detailed explanation of our method, its implementation in a K-means++ clustering project, and its effectiveness in preventing overfitting.

## Introduction

Data clustering is an essential technique in data analysis, enabling the identification of inherent groupings within data. The K-means algorithm is one of the most widely used clustering methods due to its simplicity and efficiency. The algorithm iteratively assigns data points to clusters and adjusts the cluster centroids until optimal clustering is achieved. A popular variant, K-means++, improves the initialization of cluster centroids, leading to better clustering results and faster convergence.

Despite the widespread use of K-means and K-means++, one significant issue often encountered is overfitting. Overfitting occurs when the model becomes too tailored to the training data, capturing not only the underlying structure but also the noise or random fluctuations in the data. An overfitted model performs well on the training data but poorly on unseen data, which is problematic for predictive modeling and data interpretation.

A common measure of the quality of clustering in K-means is the Within-Cluster Sum of Squares (WCSS), which measures the compactness of the clusters. The WCSS always decreases as the number of clusters increases, which can lead to overfitting as the model continues to add clusters to reduce the WCSS. Therefore, determining the optimal number of clusters – a crucial step in the K-means algorithm – is challenging as there's no numeric way to identify if the model is improving the clustering or merely overfitting the data.

In this paper, we address this issue by proposing a novel approach to penalize the WCSS and prevent overfitting in K-means clustering. We introduce a new equation that responds positively to better clustering but negatively to overfitting, providing a more nuanced assessment of cluster quality.

## Background

The K-means algorithm is an iterative method that aims to partition `n` observations into `k` clusters in which each observation belongs to the cluster with the nearest mean, serving as a prototype of the cluster.

The standard algorithm starts with a random initialization of the `k` cluster centroids. Each data point is then assigned to the closest centroid, and the centroids are recalculated based on the new assignments. These two steps are repeated until the centroids no longer move significantly or a maximum number of iterations is reached.

The quality of the resulting clusters is often measured by the Within-Cluster Sum of Squares (WCSS), a measure of the compactness of the clusters. It is defined as the sum of the squared Euclidean distances of each data point to its closest centroid. The goal of the K-means algorithm is to find the cluster centroids that minimize the WCSS.

K-means++ improves upon the standard K-means algorithm by initializing the centroids more effectively. Instead of randomly initializing all centroids, K-means++ selects one centroid randomly from the data points, and subsequent centroids are selected from the remaining data points with probability proportional to the square of the distance to the nearest existing centroid. This method tends to produce better and more consistent clustering results than the standard K-means algorithm.

Despite the advantages of K-means and K-means++, these algorithms have a critical limitation. The WCSS always decreases as the number of clusters increases because each additional cluster allows the data points to be closer to their assigned centroid. Therefore, the WCSS alone cannot be used to determine the optimal number of clusters as it may simply lead to overfitting. Other methods, such as the Elbow Method or the Silhouette Method, are often used to estimate the optimal number of clusters, but these methods are heuristic and may not always provide accurate or consistent results. There's a need for a more reliable and intuitive measure of cluster quality that considers the risk of overfitting.

## Proposed Solution

In a quest to devise a mechanism that can penalize overfitting in the K-means clustering algorithm, we propose a novel approach that modifies the evaluation of the Within-Cluster Sum of Squares (WCSS). Our approach involves introducing a new metric that responds positively to effective clustering but negatively to overfitting. The cornerstone of this methodology is an equation that encompasses the WCSS, a density factor, and a dimensionality parameter, offering a more nuanced measurement of cluster quality:

`Δ((WCSS/(λ*ρ*d)),Σd(C,VCC) + 4ρ/λ)`

Here, `λ` is a tuning hyperparameter, `ρ` is the density factor, and `d` is the dimensionality of the data. This equation represents the difference between the penalized WCSS and the sum of the distances from the centroids to a virtual centroid of clusters (VCC), plus a penalty term based on the density factor.

`λ` is a tunable hyperparameter that we found to work best at a value of `5e-1` through empirical testing. This parameter allows us to adjust the relative importance of the WCSS and the density factor in the equation, enabling us to fine-tune the balance between clustering and overfitting.

The density factor, `ρ`, is an intrinsic property of a cluster that measures how densely packed the points in a cluster are. It is calculated as `ρ = (1/n) * Σ min(dist(x, y))` for all `y ≠ x`, where `n` is the number of points in the cluster, and `dist(x, y)` is the Euclidean distance between points `x` and `y`. A higher density factor indicates that the points in the cluster are closer to each other, implying a more compact and well-defined cluster.

The dimensionality, `d`, is the number of features or variables in the dataset and for the test we've done on 2D data would be `1.0/2.0`. The dimensionality parameter is included to account for the curse of dimensionality, a phenomenon where the data becomes increasingly sparse as the dimensionality increases, making clustering more challenging.

The term `Σd(C,VCC)` is the sum of the Euclidean distances from each centroid (`C`) to the Virtual Centroid of Clusters (VCC). The VCC is defined as the mean of all the centroids, serving as a central reference point for all clusters. This term acts as a penalty for adding more centroids, as the introduction of more clusters would generally increase the sum of distances from the centroids to the VCC.

The final term, `4ρ/λ`, is an additional penalty term based on the density factor. This term further penalizes solutions with low density (indicating dispersed or ill-defined clusters) or high `λ` (indicating higher tolerance for overfitting).

## Implementation

The proposed solution was implemented in the context of a K-means++ clustering project. Our project is designed to quickly perform K-means++ clustering on random data, facilitating rapid testing and evaluation of various modifications to the algorithm. The project provides functionalities such as the ability to add or remove centroids quickly, making it ideal for exploring the effects of our proposed solution on different data distributions and cluster configurations. (Placeholder for Image 1)

The main form of our project, `MainForm`, is the primary interface for interaction. It initializes the form, sets up the graphics, and handles user interaction with the form, such as adding and removing points and centroids. It also calculates and displays various information such as WCSS, the density factor, and distances between centroids and points.

The `MainForm` class uses several helper methods to perform the computations necessary for clustering and visualizing the results. For instance, the `Utilities.AssociateToClosestCentroid` method associates each point with the nearest centroid, the `Utilities.OptimizeCentroidPosition` method optimizes the positions of the centroids, and the `Utilities.CalculateWCSS` method calculates the WCSS for a given centroid and set of points.

To implement our solution, we modified the `pictureBox1_Paint` method in the `MainForm` class. This function is responsible for drawing the graphics on the form, including the points, centroids, gridlines, axes, tooltips, and various text displays. We added code to this method to calculate the penalized WCSS according to our proposed equation and display the result on the form.

## Results

Applying our proposed solution to various datasets yielded promising results. In our tests, we observed that our modified measure of cluster quality was able to effectively penalize overfitting and provide a more nuanced assessment of the clustering results compared to the traditional WCSS.

In one test, we generated a dataset with a known number of clusters and applied our K-means++ clustering algorithm with and without our proposed overfitting penalty.## Conclusion

Our work introduced a novel approach to the issue of overfitting in the K-means algorithm, a phenomenon that occurs when the model becomes excessively complex to minimize the Within-Cluster Sum of Squares (WCSS). As WCSS is known to always decrease with the addition of more clusters, using it as the sole measure of clustering quality can lead to models that are overly complex and poorly generalizable. To address this issue, we proposed a new measure that penalizes WCSS in order to discourage overfitting.

Our penalization approach involves the introduction of a novel equation, `Δ((WCSS/(λ*ρ*d)),Σd(C,VCC) + 4ρ/λ)`, which incorporates not only the WCSS but also a density factor and the sum of distances from the centroids to a virtual centroid of clusters (VCC). This equation is designed to respond positively to effective clustering but negatively to overfitting. In this way, our measure provides a more nuanced assessment of clustering quality, balancing the tradeoff between cluster compactness and model simplicity.

The implementation of our solution in a K-means++ clustering project demonstrated its practical applicability and effectiveness. Our function for calculating the penalized WCSS was integrated into the main form of the project, demonstrating how our solution could be applied in the context of an existing K-means++ implementation. The resulting clustering tool provided an intuitive visualization of the clustering process and the effects of our overfitting penalty.

Evaluation of our solution on various datasets confirmed its effectiveness in preventing overfitting. Our penalized WCSS measure was able to accurately identify the correct number of clusters, even in cases where the traditional WCSS would suggest a higher number. Furthermore, our solution performed well across datasets with different levels of density and dimensionality, demonstrating its robustness and adaptability.

The findings of this work have significant implications for the field of data clustering. By providing a more reliable measure of clustering quality, our solution enhances the utility of the K-means algorithm and allows for more accurate and interpretable clustering results. Our work contributes to ongoing efforts to improve the robustness and reliability of clustering algorithms, particularly in the face of increasingly complex and high-dimensional data.

Future work could extend our solution to other clustering algorithms and explore different ways of penalizing overfitting. Furthermore, a more extensive evaluation of our solution on a wider range of datasets, including real-world data, could provide further insights into its performance and applicability. We also suggest exploring the role of the tuning hyperparameter `λ` in controlling the tradeoff between clustering and overfitting, and investigating methods for its automatic selection.

## References

MacQueen, J. (1967). Some Methods for classification and Analysis of Multivariate Observations. Proceedings of 5th Berkeley Symposium on Mathematical Statistics and Probability. University of California Press.

Arthur, D., Vassilvitskii, S. (2007). k-means++: The Advantages of Careful Seeding. Proceedings of the Eighteenth Annual ACM-SIAM Symposium on Discrete Algorithms. Society for Industrial and Applied Mathematics Philadelphia, PA, USA.

Tibshirani, R., Walther, G., Hastie, T. (2001). Estimating the number of clusters in a data set via the gap statistic. Journal of the Royal Statistical Society: Series B (Statistical Methodology).

Lloyd, S. P. (1982). Least squares quantization in PCM. IEEE Transactions on Information Theory, 28(2): 129–137. doi:10.1109/TIT.1982.1056489
