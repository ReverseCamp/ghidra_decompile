# CMakeList.txt: GhidraDecompile 的 CMake 项目，在此处包括源代码并定义
# 项目特定的逻辑。
#
cmake_minimum_required (VERSION 3.8)

# 指定编译器
# set(CMAKE_C_COMPILER x86_64-w64-mingw32-gcc)
# set(CMAKE_CXX_COMPILER x86_64-w64-mingw32-g++)

add_definitions(-D_WINDOWS)

project (GhidraDecompile)

set(ZLIB_DIR ${CMAKE_SOURCE_DIR}/zlib)
set(GHIDRA_DEP $ENV{GHIDRA_DEP})

# 添加 zlib 的头文件路径
include_directories(${ZLIB_DIR})
# 当前src所在目录
include_directories("E:\\Code\\GhidraDecompile\\src")
#include_directories(${GHIDRA_DEP}/include)

# 查找 zlib 的源文件
file(GLOB ZLIB_SOURCES
    ${ZLIB_DIR}/*.c
    ${ZLIB_DIR}/*.h
)

# 将 zlib 编译为静态库
add_library(zlib STATIC ${ZLIB_SOURCES} )

add_executable(TEST
  main.cc
)

add_executable (GhidraDecompile	                
  "marshal.cc"
  "space.cc"
  "float.cc"
  "address.cc"
  "pcoderaw.cc"
  "translate.cc"
  "opcodes.cc"
  "globalcontext.cc"
  "capability.cc"
  "architecture.cc"
  "options.cc"
  "graph.cc"
  "cover.cc"
  "block.cc"
  "cast.cc"
  "typeop.cc"
  "database.cc"
  "cpool.cc"
  "comment.cc"
  "stringmanage.cc"
  "modelrules.cc"
  "fspec.cc"
  "action.cc"
  "loadimage.cc"
  "varnode.cc"
  "op.cc"
  "type.cc"
  "variable.cc"
  "varmap.cc"
  "jumptable.cc"
  "emulate.cc"
  "emulateutil.cc"
  "flow.cc"
  "userop.cc"
  "multiprecision.cc"
  "funcdata.cc"
  "funcdata_block.cc"
  "funcdata_varnode.cc"
  "unionresolve.cc"
  "funcdata_op.cc"
  "pcodeinject.cc"
  "heritage.cc"
  "prefersplit.cc"
  "rangeutil.cc"
  "ruleaction.cc"
  "subflow.cc"
  "transform.cc"
  "blockaction.cc"
  "merge.cc"
  "double.cc"
  "constseq.cc"
  "coreaction.cc"
  "condexe.cc"
  "override.cc"
  "dynamic.cc"
  "crc32.cc"
  "prettyprint.cc"
  "printlanguage.cc"
  "printc.cc"
  "printjava.cc"
  "memstate.cc"
  "opbehavior.cc"
  "paramid.cc"
  "ghidra_arch.cc"
  "inject_ghidra.cc"
  "ghidra_translate.cc"
  "loadimage_ghidra.cc"
  "typegrp_ghidra.cc"
  "database_ghidra.cc"
  "ghidra_context.cc"
  "cpool_ghidra.cc"
  "ghidra_process.cc"
  "comment_ghidra.cc"
  "string_ghidra.cc"
  "signature.cc"
  "signature_ghidra.cc"
  #"callgraph.cc"			
  #"ifacedecomp.cc"			
  #"ifaceterm.cc"			
  #"interface.cc"			
  "xml.cc"
  #"grammar.cc"
)

# add_executable(Sleigh
#   "space.cc"
#   "float.cc"
#   "address.cc"
#   "pcoderaw.cc"
#   "translate.cc"
#   "opcodes.cc"
#   "globalcontext.cc"
#   "sleigh.cc"
#   "pcodecompile.cc"
#   "sleighbase.cc"
#   "slghsymbol.cc"
#   "slghpatexpress.cc"
#   "slghpattern.cc"
#   "semantics.cc"
#   "context.cc"
#   "slaformat.cc"
#   "compression.cc"
#   "filemanage.cc"
#   "slgh_compile.cc"
#   "xml.cc"
#   "pcodeparse.cc"
#   "slghparse.cc"
#   "slghscan.cc"
# )


# if (CMAKE_VERSION VERSION_GREATER 3.12)
#   set_property(TARGET GhidraDecompile PROPERTY CXX_STANDARD 20)
# endif()

link_directories(${GHIDRA_DEP}/lib)
link_directories(
  "D:\\Windows Kits\\10\\Lib\\10.0.22621.0\\um\\x64"
)
target_link_libraries(GhidraDecompile PRIVATE zlib) #libintl.a libbfd.a
#target_link_libraries(Sleigh zlib)
# TODO: 如有需要，请添加测试并安装目标。
