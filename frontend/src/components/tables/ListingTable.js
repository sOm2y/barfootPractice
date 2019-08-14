import React, { useEffect, useState } from 'react'
import { connect } from 'react-redux'
import { Table, Divider, Tag, Button, Modal } from 'antd'
import { getListings } from '../../services/listingService'
import WrappedListingForm from '../forms/ListingForm'
import { updateListing, createListing } from '../../actions/actionCreator'

const { Column } = Table

const ListingTable = ({ ...props }) => {
    const { updateListing, createListing } = props
    const [listings, setListings] = useState([])
    const [visibleCreate, setVisibleCreate] = useState(false)
    const [visibleUpdate, setVisibleUpdate] = useState(false)

    useEffect(() => {
        getListings().then(res => {
            setListings(res)
        })
    }, [])

    const handleCreate = () => {
        // TODO: Create Listing
        setVisibleCreate(true)
        createListing()
    }
    const saveCreateListing = (createListing) => {
        setVisibleCreate(false)
     
    }

    const handleCreateCancel = () => {
        setVisibleCreate(false)
    }

    const handleUpdate = (listing) => {
        setVisibleUpdate(true)
        updateListing(listing)
    }

    const saveUpdateListing = (updateListing) => {
        setVisibleUpdate(false)
    }

    const handleUpdateCancel = () => {
        setVisibleUpdate(false)
    }

    return (
        <React.Fragment>
            <h3>Listing</h3>
            <Button onClick={handleCreate} type="primary" style={{ marginBottom: 16 }}>
                Add a Listing
            </Button>
            <Modal
                title="Create Listing"
                visible={visibleCreate}
                onOk={handleCreate}
                onCancel={handleCreateCancel}
                footer={[]}
            >
                <WrappedListingForm />
            </Modal>
            <Modal
                title="Update Listing"
                visible={visibleUpdate}
                onOk={saveUpdateListing}
                onCancel={handleUpdateCancel}
                footer={[]}
            >
                <WrappedListingForm saveUpdateListing={saveUpdateListing} />
            </Modal>
            <Table rowKey={listing => listing.listingId} dataSource={listings}>

                <Column title="Price" dataIndex="price" key="price" />
                <Column title="Address" dataIndex="address" key="address" />
                <Column title="Created" dataIndex="created" key="created" />
                <Column
                    title="Status"
                    dataIndex="status"
                    key="status"
                    render={status => (
                        <span>

                            <Tag color="blue" >
                                {status}
                            </Tag>

                        </span>
                    )}
                />
                <Column
                    title="Action"
                    key="action"
                    render={(text, record) => (
                        <span>
                            <a href="" onClick={(e) => { e.preventDefault(); handleUpdate(record) }}>Update</a>
                            <Divider type="vertical" />
                            {
                                <a href="" onClick={(e) => { e.preventDefault() }}>Delete</a>
                            }
                        </span>
                    )}
                />
            </Table>
        </React.Fragment>
    )
}


const mapStateToProps = (state, props) => {
    return {

    }
}

const mapDispatchToProps = {
    updateListing,
    createListing
}


export default connect(
    mapStateToProps,
    mapDispatchToProps
)(ListingTable)
