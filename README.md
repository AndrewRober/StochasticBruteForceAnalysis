# **Comparative analysis of Stochastic, Sequential and hybrid randomized sequential ranges brute forcing.**

**Abstract.** In this research paper, we present a comprehensive
comparison and analysis of four distinct brute force algorithm
approaches: the traditional sequential brute force method, a stochastic
approach employing randomization of the sequence, a sequential method
utilizing partitioned and randomized number sets, and a sequential
technique that employs partitioned and randomized number sets, with the
additional aspect of randomizing the partitions themselves. The primary
aim of this investigation is to examine the trade-offs between these
methods, taking into account the potential benefits of randomized
algorithms in terms of enhanced performance, while acknowledging their
inherent risk of overlooking problems with close solutions that a
sequential approach may resolve more efficiently, whereas a randomized
one might miss for an extended period.

To systematically evaluate the efficiency of each approach, we conduct
experiments with both small and large number sets, focusing on the
average steps required to reach a solution. By analyzing the results in
the context of the known strengths and weaknesses of the respective
algorithms, we aim to provide a comprehensive understanding of the
relative merits of these brute force strategies. The findings of this
study hold implications for the application of these methods in various
computational domains, with the ultimate goal of optimizing
problem-solving effectiveness.

**Methodology**

In order to conduct this experiment and evaluate the efficiency of the
four brute force algorithm approaches previously outlined, we focus on
measuring the number of steps required for each method, with the
ultimate goal of determining the average number of steps taken to reach
a solution. To achieve statistically robust results, we repeat the
experiment in two runs, starting by only 1k runs and then 1 million run,
thereby allowing the law of large numbers to minimize the impact of
outliers and any instances of exceptional luck while emphasizing why
some tend to think that a randomized/stochastic approach might be
better.

Our experimental design begins by fixing the dataset size, initially
using a set of 1,000 numbers ranging from 0 to 999, followed by a larger
set of 100,000 ranging from 0 to 999,99. This approach enables us to
assess the scalability and performance of each algorithm under varying
problem sizes.

For the traditional sequential brute force method, we select a number at
random from the sorted dataset, and given the uniform distribution, we
use the index of the chosen number (plus one) as our baseline metric for
the number of steps required.

for the stochastic or sequential over randomized sets brute forcing,
instead of choosing a number at random, compare and if didn\'t solve we
then store it in a hash set and keep generating new numbers, we use an
optimize version of that were we first shuffle the numbers domain and go
throw this randomized set sequentially, but for the purpose of this
paper we will calculate the steps by using the index of the answer in
this randomized set (plus one).

By systematically analyzing the results of this experiment, we will be
able to determine the relative efficiency of the four brute force
strategies across different problem sizes, thereby providing insight
into their effectiveness and applicability in various computational
domains.

![image1](https://user-images.githubusercontent.com/54873972/236478553-38eb3ff6-7518-4f39-8774-134a472e7ad4.png)


Going forward we're labeling the result of those four methods as M1
through M4, where M1 is traditional sequential brute forcing, M2
randomized brute forcing without duplicate guessing (otherwise you can
think of it as shuffling the number set and going sequentially over this
randomized set), M3 is the same as M2 except that we first partition the
range into partitions then shuffle those partitions, M4 is the same as
M3 except we shuffle those partitions too.

**For 1K runs with 1k dataset**

| **M** | **Mean** | **Median** | **Mode** | **Min** | **Max** | **Range** | **IQR** | **Q1** | **Q2** | **Q3** |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **M1** | 463.16 | 440 | 161 | 4 | 994 | 990 | 536.5 | 203 | 440 | 739.5 |
| **M2** | 508.68 | 519.5 | 372 | 17 | 993 | 976 | 540 | 260 | 519.5 | 800 |
| **M3** | 423.84 | 411 | 63 | 1 | 982 | 981 | 425 | 192.5 | 411 | 617.5 |
| **M4** | 493.39 | 483 | 31 | 23 | 977 | 954 | 420 | 286.5 | 483 | 706.5 |

![image2](https://user-images.githubusercontent.com/54873972/236478951-42932dff-12f4-4416-af42-1d30fb27fb14.png)

![image3](https://user-images.githubusercontent.com/54873972/236478600-f66b732d-97ad-4d72-9b26-e1b04ac16bf4.png)


**For 1K runs with 100k dataset**


| **M** | **Mean** | **Median** | **Mode** | **Min** | **Max** | **Range** | **IQR** | **Q1** | **Q2** | **Q3** |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **M1** | 53022.34 | 58380.5 | 1511 | 1511 | 99295 | 97784 | 50392 | 27324 | 58380.5 | 77716 |
| **M2** | 53224.45 | 55254 | 912 | 912 | 99581 | 98669 | 55876 | 23880 | 55254 | 79756 |
| **M3** | 52656.29 | 52877.5 | 305 | 305 | 96618 | 96313 | 47558.5 | 28821.5 | 52877.5 | 76380 |
| **M4** | 50664.73 | 52183.5 | 1507 | 1507 | 99575 | 98068 | 53281 | 24751 | 52183.5 | 78032 |

![image4](https://user-images.githubusercontent.com/54873972/236478985-d5d0ec13-cf3c-4998-abce-fbbce8513ae7.png)
![image5](https://user-images.githubusercontent.com/54873972/236478991-6e9599f1-a88d-4394-b286-4c27330e45c3.png)


**For 1KK runs with 1k dataset**

| **M** | **Mean** | **Median** | **Mode** | **Min** | **Max** | **Range** | **IQR** | **Q1** | **Q2** | **Q3** |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **M1** | 500.3889 | 500 | 148 | 1 | 1000 | 999 | 500 | 251 | 500 | 751 |
| **M2** | 500.9783 | 501 | 842 | 1 | 1000 | 999 | 500 | 251 | 501 | 751 |
| **M3** | 500.0887 | 500 | 755 | 1 | 1000 | 999 | 500 | 250 | 500 | 750 |
| **M4** | 500.4035 | 501 | 23 | 1 | 1000 | 999 | 500 | 250 | 501 | 750 |

![image6](https://user-images.githubusercontent.com/54873972/236479021-ca603373-823f-4455-933b-c195be19582d.png)


**For 1KK runs with 100K dataset**

| **M** | **Mean** | **Median** | **Mode** | **Min** | **Max** | **Range** | **IQR** | **Q1** | **Q2** | **Q3** |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **M1** | 49995.2 | 50004 | 32906 | 1 | 100000 | 99999 | 49919 | 25022 | 50004 | 74941 |
| **M2** | 50017.56 | 50019 | 41655 | 1 | 100000 | 99999 | 49981.5 | 25014 | 50019 | 74995.5 |
| **M3** | 50011.55 | 49998 | 76705 | 1 | 100000 | 99999 | 49992 | 25025 | 49998 | 75017 |
| **M4** | 49987.47 | 49961 | 27129 | 1 | 100000 | 99999 | 49956 | 25001 | 49961 | 74957 |

![image7](https://user-images.githubusercontent.com/54873972/236479031-db5c302a-eb44-4564-b757-7250071afa4d.png)


**Conclusion:**

After conducting the experiment with 1k runs for both the 1,000 and
100,000 number sets, we observed that there were indeed noticeable
variations in performance, with some methods demonstrating a slight
advantage over others. Despite the presence of outliers spanning the
entire range, our findings supported our initial hypothesis. However,
when we increased the number of runs to one million for both the 1,000
and 100,000 datasets, the results revealed a remarkable convergence,
with nearly identical means for each method.

In conclusion, our study demonstrates that while one might occasionally
achieve superior results through sheer luck by employing a randomized
stochastic approach, there is no substantial long-term advantage over
the traditional sequential brute force method. As predicted by the law
of large numbers and given a uniform distribution, the performance of
the two approaches proves to be virtually identical in the long run.
Furthermore, it is worth noting that the stochastic approach may
sometimes result in inferior performance, particularly if the
sought-after number falls within the lower quartiles of the sequence.
Thus, our research suggests that, despite the potential allure of
randomized strategies, the traditional sequential brute force method
remains a consistently reliable choice for various computational
domains.
