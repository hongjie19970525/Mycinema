# Mycinema
## 1 项目需求
影院开始营业，需要开发一个售票系统，需求如下：<br>
1)	影院每天更新放映列表，系统支持实时查看：电影放映场次时间、电影概况 <br>
2)	影院提供4类影票：普通票、赠票、学生票、情侣票（赠票免费、学生票七折，情侣票八折） <br>
3)	允许用户查看某场次座位售出情况 <br>
4)	支持购票，并允许用户选座  <br>
5)	用户可以选择场次、影票类型以及空闲座位进行购票，并打印电影票 <br>
6)  系统可以对销售情况进行保存，并允许对其进行恢复 <br>

## 2 相关技术简介
1)  简单工厂模式是属于创建型模式，又叫做静态工厂方法（Static Factory Method）模式，但不属于23种GOF设计模式之一。简单工厂模式是由一个 <工厂对象决定创建出哪一种产品类的实例。简单工厂模式是工厂模式家族中最简单实用的模式，可以理解为是不同工厂模式的一个特殊实现。 <br>
2)  序列化 (Serialization)将对象的状态信息转换为可以存储或传输的形式的过程。在序列化期间，对象将其当前状态写入到临时或持久性存储区。以后，可以通过从存储区中读取或反序列化对象的状态，重新创建该对象。 <br>
3)  面向对象(Object Oriented,OO)是软件开发方法。面向对象的概念和应用已超越了程序设计和软件开发，扩展到如数据库系统、交互式界面、应用结构、应用平台、分布式系统、网络管理结构、CAD技术、人工智能等领域。面向对象是一种对现实世界理解和抽象的方法，是计算机编程技术发展到一定阶段后的产物。 <br>
4)  XML：可扩展标记语言，标准通用标记语言的子集，是一种用于标记电子文件使其具有结构性的标记语言。在电子计算机中，标记指计算机所能理解的信息符号，通过此种标记，计算机之间可以处理包含各种的信息比如文章等。它可以用来标记数据、定义数据类型，是一种允许用户对自己的标记语言进行定义的源语言。 它非常适合万维网传输，提供统一的方法来描述和交换独立于应用程序或供应商的结构化数据。是Internet环境中跨平台的、依赖于内容的技术，也是当今处理分布式结构信息的有效工具。 <br>

## 3 类图设计
![image](https://github.com/hongjie19970525/Mycinema/raw/master/1.jpg)

## 4 用例的实现思路
### 用例1的实现
#### 需求说明
1)	获取新放映列表
2)	选择“获取新放映列表”
3)	读取放映列表XML文件并将电影名称和放映时间显示在TreeView中
#### 思路分析
1)	编写相关类
2)	电影类、放映日程类、放映场次类、电影院管理类
3)	编写方法解析XML文件
4)	编写方法初始化TreeView控件
5)	编写窗体Load事件，实现控件初始化

### 用例2的实现
#### 需求说明
1)	需求说明
2)  查看电影介绍
3)  选择电影场次，“详情”面板显示电影详细信息

### 用例3的实现
#### 需求说明
1)	查看不同类型影票票价
2)  选择“普通票”，“赠送者”“学生票”“情侣票”不可用，无折扣优惠
3)  选择“学生票”，“赠送者”不可用，“详情”面板中显示默认7折优惠价 
4)  选择“赠票”，“学生折扣”不可用，“详情”面板中显示优惠价为“0”
5)  选择“情侣票”，“普通票”“学生票”“赠票”不可用，优惠面板默认8折优惠

#### 思路分析
1)	分别编写3个单选按钮的CheckedChanged事件
2)  编写学生折扣下拉列表的SelectedIndexChanged事件
3)  编写情侣折扣下拉列表的selectedIndexChanged事件

### 用例4的实现
#### 需求说明
1)	查看放映厅座位
2)  窗体加载时，显示3个放映厅座位
3)  一号放映厅（5排7列）
3)  二号放映厅（6排8列）
4)  情侣放映厅（5排3列）

### 用例5的实现
#### 需求说明
购票选择电影场次、购票类型，点击放映厅某座位进行购买

#### 思路分析
1)  编写Ticket类及其子类
2)  编写座位标签的Click事件响应lb_Click
3)  座位标签绑定lb_Click事件

### 用例6的实现
#### 需求说明
打印影票，购票完毕，自动打印电影票，并标识所选座位为红色“已售出”状态

### 用例7的实现
#### 需求说明
保存当前销售情况，选择“继续售票”，加载之前销售状况，可以查看座位售出情况

#### 思路分析
1)  编写Save()方法序列化已售出影票集合，保存当前销售情况
2)  编写Load()反序列化获得已买影票对象集合
3)  窗体加载时，加载售票信息
4)  选择场次时，显示该场座位售出情况

![image](https://github.com/hongjie19970525/Mycinema/raw/master/2.jpg)



