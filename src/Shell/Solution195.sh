# 195. Tenth Line - Easy
# Link: https://leetcode.com/problems/tenth-line

# Read from the file file.txt and output the tenth line to stdout.
awk 'NR == 10 {print $0}' file.txt
