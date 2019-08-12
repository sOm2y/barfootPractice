import React from 'react'
import { Layout, Menu, Breadcrumb } from 'antd'
import './App.css'
import WrappedNormalLoginForm from './components/forms/login';
const { Header, Content, Footer } = Layout

const App = ({ ...props })  => {
  return (
    <Layout className="layout">
      <Header>
        <div className="logo" />
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={['2']}
          style={{ lineHeight: '64px' }}
        >
          <Menu.Item key="1">nav 1</Menu.Item>
          <Menu.Item key="2">nav 2</Menu.Item>
          <Menu.Item key="3">nav 3</Menu.Item>
        </Menu>
      </Header>
      <Content style={{ padding: '0 50px' }}>
        <Breadcrumb style={{ margin: '16px 0' }}>
          <Breadcrumb.Item>Home</Breadcrumb.Item>
          <Breadcrumb.Item>List</Breadcrumb.Item>
          <Breadcrumb.Item>App</Breadcrumb.Item>
        </Breadcrumb>
        <div style={{ background: '#fff', padding: 24, minHeight: 280, maxWidth:1000, margin:"0 auto" }}>
          <WrappedNormalLoginForm />
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Barfoot Practice ©2019 Created by Yue</Footer>
    </Layout>
  );
}

export default App
