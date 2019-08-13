import React from 'react'
import { Layout, Menu } from 'antd'
import { connect } from 'react-redux'
import './App.css'
import WrappedNormalLoginForm from './components/forms/Login'
import ListingTable from './components/tables/ListingTable'
import StaffTable from './components/tables/StaffTable'


const { Header, Content, Footer } = Layout

const App = ({ ...props }) => {

  const { currentUser, isAuthenticated } = props

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
          <Menu.Item key="1">Home</Menu.Item>
        </Menu>
      </Header>
      <Content style={{ padding: '0 50px' }}>
        <div style={{ background: '#fff', padding: 24, minHeight: 280, maxWidth: 1000, margin: "0 auto" }}>

          {isAuthenticated ? <ListingTable /> : <WrappedNormalLoginForm />}
          {/* TODO: this should put into a role check service/helper */}
          {currentUser&&currentUser.role === 'SalesDepartmentAdmin'&& <StaffTable />}
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Barfoot Practice ©2019 Created by Yue</Footer>
    </Layout>
  );
}

const mapStateToProps = (state, props) => {
  return {
    currentUser: state.authReducer.user,
    isAuthenticated: state.authReducer.isAuthenticated
  }
}

const mapDispatchToProps = {
}

export default connect(mapStateToProps, mapDispatchToProps)(App)
