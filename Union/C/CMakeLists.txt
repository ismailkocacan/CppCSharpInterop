cmake_minimum_required(VERSION 3.9)
project(C C)

set(CMAKE_C_STANDARD 99)

add_library(C SHARED library.c library.h)