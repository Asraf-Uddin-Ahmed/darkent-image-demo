@echo off
G:
cd G:\darknet-master-image
darknet.exe detect cfg/yolov3.cfg yolov3.weights %1
